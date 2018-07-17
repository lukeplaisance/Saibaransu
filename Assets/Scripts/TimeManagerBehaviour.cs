using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public float slowdownAmount = 0.05f;
    public float slowndownLength = 2f;

    private void Update()
    {
        Time.timeScale += (1f / slowndownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void SlowDown()
    {
        Time.timeScale = slowdownAmount;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}
