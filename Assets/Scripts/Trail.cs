using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour {


    public string dir;
    public float speed=3;

    private int direction=1;

	
	// Update is called once per frame
	void Update () {
        if (dir.Equals("Up"))
            transform.Translate(Vector3.up * speed * direction * Time.deltaTime);
        else if (dir.Equals("Down"))
            transform.Translate(Vector3.down * speed * direction * Time.deltaTime);
        else if (dir.Equals("Right"))
            transform.Translate(Vector3.right * speed * direction * Time.deltaTime);
        else if (dir.Equals("Left"))
            transform.Translate(Vector3.left * speed * direction * Time.deltaTime);
        else if (dir.Equals("Forward"))
            transform.Translate(Vector3.forward * speed * direction * Time.deltaTime);
        else if (dir.Equals("Back"))
            transform.Translate(Vector3.back * speed * direction * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag( "Target"))
        {
            if (direction == 1)
                direction = -1;
            else
                direction = 1;
        }
    }
}
