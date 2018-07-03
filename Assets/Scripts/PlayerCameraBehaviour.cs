using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraBehaviour : MonoBehaviour
{
    public GameObject bike;
    public float currentTime = 0;
    public float totalTime = 1;
    public GameObject camera;

    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("MiddleArea"))
            return;

        while (Vector3.Distance(Camera.main.transform.position, bike.transform.position) > 1f)
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, bike.transform.position, Time.deltaTime * 50);
        }
        camera.transform.position = bike.transform.position;
	}
}
