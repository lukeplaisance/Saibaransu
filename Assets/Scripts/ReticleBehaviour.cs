﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReticleBehaviour : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;
    [SerializeField]
    private bool fired;
    [SerializeField]
    private bool active;
    public Image image;
    public GameEvent onPlayerRayHitHead;
    public GameEvent onPlayerRayHitBody;
    public GameEvent OnPlayerMissed;
    void Start()
    {
        ray = new Ray();
        image.enabled = false;
        fired = false;
        active = false;
    }
    bool aiming;
    public void ToggleImage()
    {
        image.enabled = !image.enabled;
        aiming = !aiming;
    }

    public void Shoot()
    {
        if (!aiming)
            return;
        if (!fired)
        {
            StartCoroutine(ResetAttack());
            Debug.Log(fired);
            fired = true;
            ray = new Ray(gameObject.transform.position, gameObject.transform.forward);
            Debug.DrawRay(ray.origin, transform.forward * 999, Color.green, 5.0f);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider)
                {
                    Debug.Log("Ray hit " + hit.collider.name);
                    if (hit.collider.CompareTag("P1Head"))
                    {
                        onPlayerRayHitHead.Raise();
                    }

                    if (hit.collider.CompareTag("P1Body"))
                    {
                        onPlayerRayHitBody.Raise();
                    }
                }
                else
                {
                    Debug.Log("Attack Missed");
                    OnPlayerMissed.Raise();
                }
            }
        }
    }

    //todo: move this out of update and listen for what a p1fire1 input means
    IEnumerator ResetAttack()
    {
        while(true)
        {
            yield return new WaitForSeconds(3.0f);
            fired = false;
            break;
        }
        StopAllCoroutines();
    }
}
