using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveScenes2D : MonoBehaviour 
{
	public string newLevel;

	void onTriggerEnter2D (Collider2D other)
	{
		Debug.Log ("Son dentro");
		if (other.CompareTag ("Player")) 
		{
			Debug.Log ("tag Player");
			SceneManager.LoadScene ("newLevel");
		}
		
	}


}
