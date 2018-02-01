using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMoveNew : MonoBehaviour
{

	[Header("Speed values")] 
	public float MaxThreshold = (float)Math.Log(262144, 2);
	public float MaxSpeed = (float)Math.Log(1048576, 2);
	
	[Header("Jump values")]
	public float JumpForce;
	
	public Light PLight;
	
	private Rigidbody2D _playerRb;
	private SpriteRenderer _playerSprite;
	private Animator _playerAnim;
	private GameObject[] _gameObjects;

	private float _incrSpeed;
	private double _multi=1024;
	private bool _onGround = false;
	private bool _doubleJump = true;
	private int _count = 0;
	
	void Start () {
		_playerSprite = GetComponent<SpriteRenderer> ();
		_playerRb = GetComponent<Rigidbody2D> ();
		_playerAnim = GetComponent<Animator> ();
	}
	


	private void FixedUpdate()
	{
		
		//Movement section
		
		//_playerAnim.SetBool ("isWalking", false);

		/*if (_incrSpeed < MaxThreshold)
			_playerAnim.SetBool("isRunning", false);
		*/
		if (_playerRb.velocity.x != 0.0f)
		{
			if (!_playerAnim.GetBool("isWalking")&&!_playerAnim.GetBool("isFalling"))
				_playerAnim.SetBool ("isWalking", true);
			_multi+=300;
			_multi = _multi % 262144;
		}
		else if (_playerRb.velocity.x == 0.0f)
		{
			_playerAnim.SetBool("isWalking", false);
			_multi = 1024;
		}


		_incrSpeed = (float) Math.Log(_multi, 2);
		
		float x = Input.GetAxis("Horizontal");
		
		if (x < 0)
			_playerSprite.flipX = true;
		else if (x>0)
			_playerSprite.flipX = false;

		/*if (_incrSpeed > MaxThreshold)
			_playerAnim.SetBool("isRunning", true);*/
		_playerRb.AddForce(new Vector2(x, 0)*_incrSpeed);
		
		
		//Jump section
		if (Input.GetKeyDown(KeyCode.Space)&&(_onGround||_doubleJump))
		{
			_count++;
			if (_count == 2)
			{
				_count = 0;
				_doubleJump = false;
			}

			_onGround = false;
			_playerRb.AddForce(Vector2.up * JumpForce);
			_playerAnim.SetBool("isJumping", true);
		}
		
		if (_playerRb.velocity.y < 0.0f)
		{
			_playerRb.gravityScale = 2;
			_playerAnim.SetBool("isJumping", false);
			_playerAnim.SetBool("isFalling", true);
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Ground"))
		{
			_playerRb.gravityScale = 1;
			_playerAnim.SetBool("isFalling", false);
			_playerAnim.SetBool("isJumping", false);
			_onGround = true;
			_doubleJump = true;
			_count = 0;
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Collectible"))
		{
			PLight.intensity = PLight.intensity * 1.5f;

			//FindObjectOfType<AudioManager> ().Play ("magic");

			/*foreach (GameObject g in _gameObjects) 
			{
				if (!g.GetComponent<Image> ().enabled) {
					g.GetComponent<Image> ().enabled = true;
					break;
				}
			}*/

			Destroy(collision.gameObject);
		}
	}
}
