using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownBikeBehaviour : MonoBehaviour
{
    public GameObject area;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MiddleArea"))
        {
            Debug.Log("bike hit");
            var bb = other.gameObject.GetComponent<BikeMovementBehaviour>();
            bb.speed = 10;
        }
    }

}
