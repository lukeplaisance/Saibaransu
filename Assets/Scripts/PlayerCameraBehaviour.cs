using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraBehaviour : MonoBehaviour
{
    float fov = Camera.main.fieldOfView;
    float start = 20.0f;
    float end = 10.0f;
    public float totalTime = 1;
    public float currentTime = 0;

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
            fov = Mathf.Lerp(start, end, interprolant);
            Camera.main.fieldOfView = fov;
        }
        else
            return;
	}
}
