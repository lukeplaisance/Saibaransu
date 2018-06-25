using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LookAtTargetBehaviour : MonoBehaviour
{
    public CinemachineVirtualCameraBase vcam;

    public void LookAt(Transform target)
    {
        vcam = GetComponent<CinemachineVirtualCameraBase>();
        target = vcam.LookAt;
    }
    public void Follow(Transform target)
    {
        vcam = GetComponent<CinemachineVirtualCameraBase>();
        target = vcam.Follow;
    }
}
