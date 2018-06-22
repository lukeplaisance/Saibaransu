using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update ()
    {
        if(gameObject.CompareTag("Player1"))
        {
            var movement = transform.position * Time.deltaTime;
            rb.AddForce(movement * speed);
        }
        if(gameObject.CompareTag("Player2"))
        {
            var movement = -transform.position * Time.deltaTime;
            rb.AddForce(movement * speed);
        }
	}
}
