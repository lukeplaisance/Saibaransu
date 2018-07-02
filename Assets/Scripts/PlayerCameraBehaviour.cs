using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraBehaviour : MonoBehaviour
{
    public GameObject bike;
    public float currentTime = 0;
    public float totalTime = 1;

    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        var interprolent = currentTime / totalTime;
        while (Camera.main.transform.position != bike.transform.position)
        {
            if (other.gameObject.CompareTag("MiddleArea"))
            {
                Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, bike.transform.position, interprolent);
            }
        }
	}
}
