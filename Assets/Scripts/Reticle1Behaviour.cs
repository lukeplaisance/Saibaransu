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
    private bool fired = false;
    private RaycastHit hit;
    private Ray ray;
    public Camera camera;
    void Start ()
	{
        UI = GameObject.Find("Canvas");
	    objectRectTransform = UI.GetComponent<RectTransform>();
	    ray = new Ray();
	}

    void Update ()
    {

        ray = camera.ScreenPointToRay(objectRectTransform.position);

        if (Input.GetButton("P1Horizontal") && Input.GetAxis("P1Horizontal") > 0)
        {
            if (transform.localPosition.x + 50 <= objectRectTransform.rect.width / 2)
            {
                transform.position += new Vector3(speed, 0, 0);
            }
        }

        if (Input.GetButton("P1Horizontal") && Input.GetAxis("P1Horizontal") < 0)
        {
            if (transform.localPosition.x >= -objectRectTransform.rect.width / 2)
            {
                transform.position += new Vector3(-speed, 0, 0);
            }
        }

        if (Input.GetButton("P1Vertical") && Input.GetAxis("P1Vertical") < 0)
        {
            if (transform.localPosition.y - 20 >= -objectRectTransform.rect.height / 2)
            {
                transform.position += new Vector3(0, -speed, 0);
            }
        }

        if (Input.GetButton("P1Vertical") && Input.GetAxis("P1Vertical") > 0)
        {
            if (transform.localPosition.y + 35 <= objectRectTransform.rect.height / 2)
            {
                transform.position += new Vector3(0, speed, 0);
            }
        }

        if (Input.GetButton("P1Fire1"))
        {
            //if (!fired)
            //{
            //    fired = true;
                if (Physics.Raycast(ray, out hit/*transform.forward, out hit*/))
                {
                    if (hit.collider)
                    {
                        Debug.Log("Ray Hit" + hit.collider.name);
                        Debug.DrawRay(objectRectTransform.position, transform.forward, Color.green);
                    }
                }
            //}
        }
    }
}
