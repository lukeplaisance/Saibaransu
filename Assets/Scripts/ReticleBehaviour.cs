
using UnityEngine;
using UnityEngine.UI;

public class ReticleBehaviour : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;
    private bool fired;
    private bool active;
    public Image image;

    void Start()
    {
        ray = new Ray();
        image.enabled = false;
        fired = false;
        active = false;
    }

    public void ToggleImage()
    {
        image.enabled = !image.enabled;
    }

    public void Shoot()
    {
        fired = true;
        ray = new Ray(gameObject.transform.position, gameObject.transform.forward);
        Debug.DrawRay(ray.origin, transform.forward * 999, Color.green, 5.0f);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider)
            {
                Debug.Log("Ray hit " + hit.collider.name);
            }
            else
            {
                Debug.Log("Attack Missed");
            }
        }
    }

    //todo: move this out of update and listen for what a p1fire1 input means
  
}
