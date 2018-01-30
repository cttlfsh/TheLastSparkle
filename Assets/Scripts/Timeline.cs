using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Timeline : MonoBehaviour {



	public CameraManager camera;
	PlayableDirector parent;
	bool changeCamera;
	// Use this for initialization
	void Start () {
		parent = transform.parent.GetComponent<PlayableDirector> (); 
		changeCamera = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag ("Player")) {
			Debug.Log ("Got the player man!");
			parent.Play ();
			changeCamera = true;
			camera.ChangeCamera (1);

			StartCoroutine(LoadLevel());
		}
	}

	IEnumerator LoadLevel ()
	{
		yield return new WaitForSeconds(10f);

		SceneManager.LoadScene("menu");
	}
}
