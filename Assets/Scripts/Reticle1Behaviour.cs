using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle1Behaviour : MonoBehaviour
{
    private GameObject UI;
    private RectTransform objectRectTransform;

	void Start ()
	{
        UI = GameObject.Find("Canvas");
	    objectRectTransform = UI.GetComponent<RectTransform>();
	}



    //USE OBJECT RECT TRANSFORM INSTEAD OF NUMBERS

    void Update () {
        if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") > 0)
        {
            if (transform.localPosition.x + 25 <= 129.5)
            {
                transform.position += Vector3.right * 3;
            }
        }

        if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") < 0)
        {
            if (transform.localPosition.x - 25 >= -259)
            {
                transform.position += Vector3.left * 3;
            }
        }

        if (Input.GetButton("Vertical") && Input.GetAxis("Vertical") < 0)
        {
            if (transform.localPosition.y - 25 >= -146)
            {
                transform.position += Vector3.down * 3;
            }
        }

        if (Input.GetButton("Vertical") && Input.GetAxis("Vertical") > 0)
        {
            if (transform.localPosition.y + 25 <= 146)
            {
                transform.position += Vector3.up * 3;
            }
        }
    }
}
