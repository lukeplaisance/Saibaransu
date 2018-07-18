using UnityEngine;

//feedback:
//if you ever have two scripts that are copy pasted, you can merge them somehow
//get someone to review


public class CameraControllerBehaviour : MonoBehaviour
{
    [SerializeField]
    private PlayerConfig config;
    [Header("Camera Values")]
    [SerializeField]
    private Transform _player;
    [SerializeField]
    private float _rotationSpeed = 10;
    private bool _isFirstPerson;
    [SerializeField]
    private Camera _camera;

    private void Start()
    {
        //_camera = GetComponent<Camera>();

    }

    private void Update()
    {
        if (Input.GetButtonDown(config._fireinput1))
        {
            config.InputFire1.Raise();
        }

        if (Input.GetButtonDown(config._fireinput2))
        {
            config.InputFire2.Raise();
        }

        //ToDo: make a vector for rotation and change that
        if (Input.GetAxis(config._horizontalinput) > 0)
            _camera.transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0f);

        if (Input.GetAxis(config._horizontalinput) < 0)
            _camera.transform.Rotate(0, -_rotationSpeed * Time.deltaTime, 0f);

        if (Input.GetAxis(config._verticalinput) < 0)
            _camera.transform.Rotate(_rotationSpeed * Time.deltaTime, 0, 0f);

        if (Input.GetAxis(config._verticalinput) > 0)
            _camera.transform.Rotate(-_rotationSpeed * Time.deltaTime, 0, 0f);

    }
}