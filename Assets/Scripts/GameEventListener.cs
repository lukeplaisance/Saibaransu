using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventListener : MonoBehaviour
{

    public GameEvent Event;

    private UnityEvent Response;

    public void OnEventRaised()
    {
        Response.Invoke();
    }

}
