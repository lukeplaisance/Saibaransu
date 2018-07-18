using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateBehaviour : MonoBehaviour {

	//gamestart
    //gameend
    //roundend
    [Header("Events")]
    [SerializeField]
    public GameEvent GameStarted;

    [SerializeField]
    public GameEvent GameEnded;

    [SerializeField]
    public GameEvent RoundStart;

    [SerializeField]
    public GameEvent RoundEnd;

    public void Start()
    {
        GameStarted.Raise();
    }
}
