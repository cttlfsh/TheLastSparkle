using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class skipScript : MonoBehaviour 
{
	public Canvas skip;
	public Button skipButton;

	void Start ()
	{
		skip = skip.GetComponent<Canvas> ();
		skipButton = skipButton.GetComponent<Button> ();
	}

	public void skipIntro()
	{
		SceneManager.LoadScene ("Level1.1"); //da cambiare in caso
	}
}
