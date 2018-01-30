using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAppear : MonoBehaviour 
{
	public Image image1;
	public Image image2;
	public Image image3;
	public Image image4;

	void Start()
	{
		image1.enabled = true;
		image2.enabled = false;
		image3.enabled = false;
		image4.enabled = false;
		StartCoroutine(timer());
	}

	IEnumerator timer ()
	{
		yield return new WaitForSeconds (5);
		image1.enabled = false;
		image2.enabled = true;

		yield return new WaitForSeconds (5);
		image2.enabled = false;
		image3.enabled = true;

		yield return new WaitForSeconds (5);
		image3.enabled = false;
		image4.enabled = true;

		yield return new WaitForSeconds (5);
		image4.enabled = false;

	}

}
