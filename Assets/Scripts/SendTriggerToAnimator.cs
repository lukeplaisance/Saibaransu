using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendTriggerToAnimator : MonoBehaviour
{
    public Animator _animator;
    public string _triggerName;

    public void SendTrigger()
    {
        _animator.SetTrigger(_triggerName);
    }
}
