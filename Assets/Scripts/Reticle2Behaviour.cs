using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Reticle2Behaviour : MonoBehaviour {
    public float speed = .01f;
    void Start () {
		
	}
	
	void Update () {
        if (Input.GetButton("Horizontal1") && Input.GetAxis("Horizontal1") > 0)
        {
            transform.position += new Vector3(speed, 0, 0);
        }
        if (Input.GetButton("Horizontal1") && Input.GetAxis("Horizontal1") < 0)
        {
            transform.position += new Vector3(-speed, 0, 0);
        }
        if (Input.GetButton("Vertical1") && Input.GetAxis("Vertical1") < 0)
        {
            transform.position += new Vector3(0, -speed, 0);
        }
        if (Input.GetButton("Vertical1") && Input.GetAxis("Vertical1") > 0)
        {
            transform.position += new Vector3(0, speed, 0);
        }
    }
}
