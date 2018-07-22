using UnityEngine;

public class BikeMovementBehaviour : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ResetVelocity()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.forward;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce((transform.forward * speed) * Time.fixedDeltaTime, ForceMode.Impulse);
    }
}
