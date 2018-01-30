using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CameraManager : MonoBehaviour {
	public GameObject player;
	public GameObject[] gameCameras;
	 

    int cameraIndex = 0;
	// Use this for initialization
	void Start () {
		FocusCamera(cameraIndex);
	}
	
	// Update is called once per frame
	void Update () {

		//if (Input.GetMouseButtonDown (0)) {
		//	ChangeCamera (1);
		//}
		//if (Input.GetMouseButtonDown (1)) {
		//	ChangeCamera (-1);
		//}

		
	}

    void FocusCamera(int index) {
        for (int i=0; i < gameCameras.Length; i++) {
			gameCameras[i].SetActive(i==index);
        }
    }

	public void ChangeCamera(int direction) {
		cameraIndex += direction;

		if (cameraIndex >= gameCameras.Length) {
			cameraIndex = 0;
		}
		if (cameraIndex < 0) {
			cameraIndex = gameCameras.Length - 1;
		}

		FocusCamera (cameraIndex);
    }

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag ("Player")) {
			PlayableDirector pd = collision.GetComponentInParent<PlayableDirector> ();
			Debug.Log("ok");
		}
	}
}
