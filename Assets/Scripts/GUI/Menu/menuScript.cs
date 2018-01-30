using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour 
{

	public Canvas quitMenu;
	public Canvas comandi;
	public Button startText;
	public Button exitText;

	// Use this for initialization
	void Start () 
	{
		quitMenu = quitMenu.GetComponent<Canvas> ();
		comandi = comandi.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		quitMenu.enabled = false;
		comandi.enabled = false;
		
	}

	public void ExitPress ()
	{
		quitMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;

	}

	public void ComandPress()
	{
		comandi.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
	}

	public void NoPress ()
	{
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
	}

	public void NeinPress()
	{
		comandi.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
	}

	public void startLevel ()
	{
		SceneManager.LoadScene ("cinematica"); //da cambiare con il nome della scena prima (livello livello)
	}

	public void ExitGame ()
	{
		Application.Quit ();
		Debug.Log ("Quit game");
	}
}
