using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Trail : MonoBehaviour {


    public string dir;
    public float speed=3;

    private int direction=1;
    private bool enter = false;

    void Start()
    {
        StartCoroutine(wait());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag( "Target"))
        {
            enter = true;
            if (direction == 1)
                direction = -1;
            else
                direction = 1;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Target"))
            enter = false;
    }

    IEnumerator wait()
    {
        while (!enter)
        {
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
            yield return null;
        }

        yield return new WaitForSeconds(3f);
        enter = false;
        StartCoroutine(wait());
    }
}
