using UnityEngine;
using UnityEngine.UI;

public class CameraControllerBehaviourP1 : MonoBehaviour
{
    public GameObject player;
    public bool isFirstPerson;
    public GameObject camera;
    private float rotationSpeed = 10;


    void Start()
    {

    }

    private void Update()
    {
        camera.transform.parent = player.transform;
        if (Input.GetButton("Fire2"))
        {
            isFirstPerson = true;
            camera.transform.position =
                Vector3.Lerp(camera.transform.position, player.transform.position, Time.deltaTime * 10);
        }

        if (isFirstPerson)
        {
           
            if (Input.GetButton("P1Horizontal") && Input.GetAxis("P1Horizontal") > 0)
            {
                transform.Rotate(0, rotationSpeed * Time.deltaTime, 0f);
            }

            if (Input.GetButton("P1Horizontal") && Input.GetAxis("P1Horizontal") < 0)
            {
                transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0f);
            }

            if (Input.GetButton("P1Vertical") && Input.GetAxis("P1Vertical") < 0)
            {
                transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0f);
            }

            if (Input.GetButton("P1Vertical") && Input.GetAxis("P1Vertical") > 0)
            {
                transform.Rotate(-rotationSpeed * Time.deltaTime, 0, 0f);
            }
        }
    }
}
