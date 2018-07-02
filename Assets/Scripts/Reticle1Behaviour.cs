using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEditor;
using UnityEngine;

public class Reticle1Behaviour : MonoBehaviour
{
    private GameObject UI;
    private RectTransform objectRectTransform;
    public float speed = .01f;

	void Start ()
	{
        UI = GameObject.Find("Canvas");
	    objectRectTransform = UI.GetComponent<RectTransform>();
	}

    void Update () {

        if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") > 0)
        {
            if (transform.localPosition.x + 50 <= -objectRectTransform.rect.width / 2)
            {
                transform.position += new Vector3(speed, 0, 0);
            }
        }

        if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") < 0)
        {
            if (transform.localPosition.x >= objectRectTransform.rect.width / 2)
            {
                transform.position += new Vector3(-speed, 0, 0);
            }
        }

        if (Input.GetButton("Vertical") && Input.GetAxis("Vertical") < 0)
        {
            if (transform.localPosition.y - 20 >= -objectRectTransform.rect.height / 2)
            {
                transform.position += new Vector3(0, -speed, 0);
            }
        }

        if (Input.GetButton("Vertical") && Input.GetAxis("Vertical") > 0)
        {
            if (transform.localPosition.y + 50 <= objectRectTransform.rect.height / 2)
            {
                transform.position += new Vector3(0, speed, 0);
            }
        }
    }
}
