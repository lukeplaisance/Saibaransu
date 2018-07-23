using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownBehaviour : MonoBehaviour
{
    public float StartTime = 3;
    public float timer = 3;
    public GameObject Bike;
    public Text CountDown;

    public void Start()
    {
        timer = StartTime;
    }

    public void ResetTimer()
    {
        timer = StartTime;
        Bike.GetComponent<BikeMovementBehaviour>().enabled = false;
        CountDown.enabled = true;
    }

    private void Update()
    {
        timer -= Time.unscaledDeltaTime;
        int time = (int)timer + 1;
        CountDown.text = time.ToString();
        if(timer < 0)
        {
            Bike.GetComponent<BikeMovementBehaviour>().enabled = true;
            CountDown.enabled = false;
        }
    }
}
