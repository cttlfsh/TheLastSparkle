using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("Forces")]
    public float movementForces;
    public float jumpingForces;
    [Header("Abilities")]
    public int numberOfJumps = 2;
    [Header("PLight")]
    public Light PLight;

	int jumps;
	bool isGrounded;
	Rigidbody2D playerRB;
	SpriteRenderer playerSprite;
	Animator playerAnim;

	// Use this for initialization
	void Start () {
		playerSprite = GetComponent<SpriteRenderer> ();
		playerRB = GetComponent<Rigidbody2D> ();
		playerAnim = GetComponent<Animator> ();



	}

	void FixedUpdate(){

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


		//	StartCoroutine (AnimationWait());

		//	playerAnim.SetBool ("isJumping", false);
		}
	}

	//IEnumerator AnimationWait(){
	//	yield return new WaitForSeconds (3);
	//}

	void Jump(){
		if (jumps > 0) {
			playerRB.AddForce (new Vector2 (0, jumpingForces));
			playerAnim.SetBool ("isJumping", true);
			isGrounded = false;
			jumps--;
			//playerAnim.SetBool ("isJumping", false);
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
			jumps = numberOfJumps;
			isGrounded = true;
			playerAnim.SetBool ("isJumping", false);
		}

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            PLight.intensity = PLight.intensity * 1.5f;
            Destroy(collision.gameObject);
        }
            
    }
}
