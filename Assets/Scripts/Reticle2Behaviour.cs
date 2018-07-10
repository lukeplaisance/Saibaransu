using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Reticle2Behaviour : MonoBehaviour {
    public float speed = .01f;
    private GameObject UI;
    private RectTransform objectRectTransform;

    void Start () {
        UI = GameObject.Find("Canvas");
        objectRectTransform = UI.GetComponent<RectTransform>();
    }
	
	void Update () {
        if (Input.GetButton("P2Horizontal") && Input.GetAxis("P2Horizontal") > 0)
        {
            if (transform.localPosition.x + 25 <= objectRectTransform.rect.width / 2)
            {
                transform.position += new Vector3(-speed, 0, 0);
            }
        }
        if (Input.GetButton("P2Horizontal") && Input.GetAxis("P2Horizontal") < 0)
        {
            if (transform.localPosition.x - 25 >= -objectRectTransform.rect.width / 2)
            {
                transform.position += new Vector3(speed, 0, 0);
            }
        }
        if (Input.GetButton("P2Vertical") && Input.GetAxis("P2Vertical") < 0)
        {
            if (transform.localPosition.y - 20 >= -objectRectTransform.rect.height / 2)
            {
                transform.position += new Vector3(0, -speed, 0);
            }
        }
        if (Input.GetButton("P2Vertical") && Input.GetAxis("P2Vertical") > 0)
        {
            if (transform.localPosition.y + 35 <= objectRectTransform.rect.height / 2)
            {
                transform.position += new Vector3(0, speed, 0);
            }
        }
    }
}
