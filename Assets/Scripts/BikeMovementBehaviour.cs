using UnityEngine;

public class BikeMovementBehaviour : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * speed);
    }
}
