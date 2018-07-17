using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{

    public GameEvent Event;

    private UnityEvent Response = new UnityEvent();

    public void OnEventRaised()
    {
        Response.Invoke();
    }

    private void Start()
    {
        Response.AddListener(Output);
    }

    public void Output()
    {
        Debug.Log("Event Triggered");
    }

}
