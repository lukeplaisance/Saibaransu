using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownBike : MonoBehaviour
{
    public GameObject bike;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("MiddleArea"))
        {
            Debug.Log("bike hit");
            var bb = other.gameObject.GetComponent<BikeMovementBehaviour>();
            bb.speed -= 10;
        }
    }

}
