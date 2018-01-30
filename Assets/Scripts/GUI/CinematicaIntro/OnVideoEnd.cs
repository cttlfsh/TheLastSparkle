using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnVideoEnd : MonoBehaviour {

	public UnityEngine.Video.VideoPlayer player;

	// Use this for initialization
	void Start () 
	{
		player.loopPointReached += EndReached;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void EndReached(UnityEngine.Video.VideoPlayer vp)
	{
		SceneManager.LoadScene ("Cinemachine (Stage 1 ok)");
	}
}
