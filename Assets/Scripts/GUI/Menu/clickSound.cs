using System.Collections;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Button))]
public class clickSound : MonoBehaviour 
{

	public AudioClip sound;

	private Button button { get { return GetComponent<Button> ();}}
	private AudioSource source { get { return GetComponent<AudioSource> ();}}



	// Use this for initialization
	void Start () 
	{
		gameObject.AddComponent<AudioSource> ();
		source.clip = sound;
		source.playOnAwake = false;
		//Any other settings

		button.onClick.AddListener (() => PlaySound ());
	}
	
	void PlaySound ()
	{
		source.PlayOneShot (sound);
	}
}
