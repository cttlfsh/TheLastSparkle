using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

	public static bool GameIsPaused = false;

	public GameObject GameOverMenuUI;

	/* void Update () {
		if(Player è morto)
		{
			Pause();
		}
	} */

	void Pause()
	{
		GameOverMenuUI.SetActive (true);
		Time.timeScale = 0f;
		GameIsPaused = true;
		FindObjectOfType<AudioManager> ().Play ("rain");
	}

	public void LoadMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene ("menu");
	}
		
}
