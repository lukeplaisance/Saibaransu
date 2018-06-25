using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LookAtTargetBehaviour : MonoBehaviour
{
    public Transform target;
    public CinemachineVirtualCameraBase vcam;

    public void LookAt()
    {
        vcam.GetComponent<CinemachineVirtualCameraBase>();
    }
    public void Follow()
    {
        vcam.GetComponent<CinemachineVirtualCameraBase>();
    }
}
