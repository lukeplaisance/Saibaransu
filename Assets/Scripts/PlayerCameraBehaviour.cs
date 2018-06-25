using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraBehaviour : MonoBehaviour
{
    float fov;
    float newFov = 10.0f;
    public float totalTime = 1;
    public float currentTime = 0;

    void Start()
    {
        fov = Camera.main.fieldOfView;
    }

    void Update ()
    {
        var interprolant = currentTime / totalTime; //get percentage. The percentage of how long it would take
        if (Input.GetButton("Fire2"))
        {
            currentTime = currentTime + Time.deltaTime;
            if (currentTime >= totalTime)
            {
                currentTime = 0;
            }
            fov = Mathf.MoveTowards(fov, newFov, currentTime);
            Camera.main.fieldOfView = fov;
        }
	}
}
