using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    [Header("Forces")]
    public float movementForces;
    public float jumpingForces;
    [Header("Abilities")]
    public int maxNumberOfJumps = 2;
    [Header("PLight")]
    public Light PLight;

	public int jumps;
	bool isGrounded;
	Rigidbody2D playerRB;
	SpriteRenderer playerSprite;
	Animator playerAnim;
	GameObject[] gameobjects;

	// Use this for initialization
	void Start () {
		playerSprite = GetComponent<SpriteRenderer> ();
		playerRB = GetComponent<Rigidbody2D> ();
		playerAnim = GetComponent<Animator> ();

		gameobjects = GameObject.FindGameObjectsWithTag ("orb");

	}

	void FixedUpdate(){

		//Debug.Log (playerRB.velocity.y);
		if (playerRB.velocity.y < 0.0f) {
			playerAnim.SetBool("isJumping", false);
			playerAnim.SetBool("isFalling", true);
		}


		ProcessInput ();
	}

	void ProcessInput(){
		playerAnim.SetBool ("isWalking", false);

		//Handles player movement on XZ plane
		if (((Input.GetKey (KeyCode.LeftArrow)) || (Input.GetKey (KeyCode.A)))) {
			StartWalking ();
			playerSprite.flipX = true;
			//Debug.Log ("Im out");
			playerRB.AddForce (new Vector2(-1 * movementForces * Time.fixedDeltaTime, 0));
			//Debug.Log ("Im in the middle  " + playerRB.velocity.sqrMagnitude);
			if (playerRB.velocity.sqrMagnitude > 0.1f) {
				//Debug.Log ("Im In");
				playerRB.velocity *= 0.95f;
			}
		}
		
		if ((Input.GetKey (KeyCode.RightArrow)) || (Input.GetKey (KeyCode.D))) {
			StartWalking ();
			playerSprite.flipX = false;
			playerRB.AddForce (new Vector2(1 * movementForces * Time.fixedDeltaTime, 0));
			if (playerRB.velocity.sqrMagnitude > 0.1f) {
				//Debug.Log ("Im In");
				playerRB.velocity *= 0.95f;
			}
		}


		//Check if the player can jump and eventually jumps
		if (Input.GetKeyDown (KeyCode.Space)) {
			Jump ();
		}
	}

	void Jump(){
		if (jumps > 0) {
			playerAnim.SetBool ("isJumping", true);
			playerRB.AddForce (new Vector2 (0, jumpingForces));
			isGrounded = false;
			jumps--;
		}
		if (jumps == 0)
			return;
	}

	void StartWalking() {
		bool walking = playerRB.velocity != Vector2.zero;
		playerAnim.SetBool ("isWalking", walking);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		//Verifico se sono con i piedi per terra
		if (coll.gameObject.tag == "Ground") {
			//Debug.Log ("Dentro");
			jumps = maxNumberOfJumps;
			isGrounded = true;
			playerAnim.SetBool ("isFalling", false);
		}

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Collectible"))
		{
			PLight.intensity = PLight.intensity * 1.5f;

			FindObjectOfType<AudioManager> ().Play ("magic");

			foreach (GameObject g in gameobjects) 
			{
				if (!g.GetComponent<Image> ().enabled) {
					g.GetComponent<Image> ().enabled = true;
					break;
				}
			}

			Destroy(collision.gameObject);
		}

	}
}
