using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraBehaviour : MonoBehaviour
{
    public GameObject bike;
    public float currentTime = 0;
    public float totalTime = 1;
    public GameObject camera;
    public bool isFirstPerson;
    public bool isThirdPerson;

    void Start()
    {
        isFirstPerson = false;
        isThirdPerson = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("MiddleArea"))
            return;

        while (Vector3.Distance(Camera.main.transform.position, bike.transform.position) > 1f)
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, bike.transform.position, Time.deltaTime * 50);
            isFirstPerson = true;
            isThirdPerson = false;
        }
        camera.transform.position = bike.transform.position;
	}
}
