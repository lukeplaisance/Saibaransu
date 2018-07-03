using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAreaBehaviour : MonoBehaviour
{
    TimeManagerBehaviour timeManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            timeManager.SlowDown();
        }
    }

}
