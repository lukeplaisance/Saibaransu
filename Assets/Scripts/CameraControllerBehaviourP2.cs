using UnityEngine;

public class CameraControllerBehaviourP2 : MonoBehaviour
{
    public GameObject player;
    public bool isFirstPerson;
    public GameObject camera;
    private float rotationSpeed = 10;
    private void Update()
    {
        camera.transform.parent = player.transform;
        if (Input.GetButton("Fire2"))
        {
            isFirstPerson = true;
            camera.transform.position = Vector3.Lerp(camera.transform.position, player.transform.position, Time.deltaTime * 10);
        }

        //if (FirstPersonState)

        if (Input.GetButton("P2Horizontal") && Input.GetAxis("P2Horizontal") > 0)
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0f);
        }

        if (Input.GetButton("P2Horizontal") && Input.GetAxis("P2Horizontal") < 0)
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0f);
        }

        if (Input.GetButton("P2Vertical") && Input.GetAxis("P2Vertical") < 0)
        {
            transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0f);
        }

        if (Input.GetButton("P2Vertical") && Input.GetAxis("P2Vertical") > 0)
        {
            transform.Rotate(-rotationSpeed * Time.deltaTime, 0, 0f);
        }
    }
}
