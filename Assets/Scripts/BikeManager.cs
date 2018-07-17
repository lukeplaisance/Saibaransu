using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BikeManager : MonoBehaviour
{
    
    [HideInInspector]
    public int m_RoundWin;

    [SerializeField]
    private BikeMovementBehaviour m_Movement;
    [SerializeField]
    private CameraControllerBehaviour m_Camera;

    public void DisableControls()
    {
        m_Movement.enabled = false;
        m_Camera.enabled = false;
    }

    public void EnableControls()
    {
        m_Movement.enabled = true;
        m_Camera.enabled = true;
    }
}
