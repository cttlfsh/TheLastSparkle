using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

	Animator boss;
	float counter = 0f;
	// Use this for initialization
	void Start () {
		boss = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(counter%500 == 0){
			boss.SetBool("isAttacking", true);
		} else {
			boss.SetBool("isAttacking", false);
		}
		counter++;
	}
}
