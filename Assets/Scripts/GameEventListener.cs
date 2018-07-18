using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{

    public GameEvent Event;

    [SerializeField]
    private UnityEvent Response;

    public void OnEventRaised()
    {
        Response.Invoke();
    }

    private void OnEnable()
    {
        Event.Subscribe(this);
    }

    void OnDisable()
    {
        Event.UnSubscribe(this);
    }

}
