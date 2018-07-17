using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BikeManager : MonoBehaviour
{
    public GameObject m_Instance;
    [HideInInspector]
    public int m_RoundWin;
    private BikeMovementBehaviour m_Movement;
    private CameraControllerBehaviour m_Camera;

    public void Setup()
    {
        m_Movement = m_Instance.GetComponent<BikeMovementBehaviour>();
        m_Camera = m_Instance.GetComponent<CameraControllerBehaviour>();
    }

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
