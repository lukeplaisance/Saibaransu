using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAreaBehaviour : MonoBehaviour
{
    public TimeManagerBehaviour timeManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other != null)
        {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("bike hit");
                timeManager.SlowDown();
            }
            else
                return;
        }
        
    }

}
