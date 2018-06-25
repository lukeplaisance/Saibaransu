using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle2Behaviour : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
        if (Input.GetButton("Horizontal1") && Input.GetAxis("Horizontal1") > 0)
        {
            transform.position += Vector3.right * 3;
        }
        if (Input.GetButton("Horizontal1") && Input.GetAxis("Horizontal1") < 0)
        {
            transform.position += Vector3.left * 3;
        }
        if (Input.GetButton("Vertical1") && Input.GetAxis("Vertical1") < 0)
        {
            transform.position += Vector3.down * 3;
        }
        if (Input.GetButton("Vertical1") && Input.GetAxis("Vertical1") > 0)
        {
            transform.position += Vector3.up * 3;
        }
    }
}
