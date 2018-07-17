using UnityEngine;

//feedback:
//if you ever have two scripts that are copy pasted, you can merge them somehow
//get someone to review


public class CameraControllerBehaviour : MonoBehaviour
{
    
    [Header("Input Values")]
    [SerializeField]
    private string _verticalinput = "P1Vertical";
    [SerializeField]
    private string _fireinput = "P1Fire2";
    [SerializeField]
    private string _horizontalinput = "P1Horizontal";

    

    [Header("Camera Values")]
    [SerializeField]
    private Transform _player;
    [SerializeField]
    private float _rotationSpeed = 10;

    private bool _isFirstPerson;
    private Camera _camera;
    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        _camera.transform.parent = _player;
        if (Input.GetButton(_fireinput))
        {
            _isFirstPerson = true;
            _camera.transform.position =
                Vector3.Lerp(_camera.transform.position, _player.position, Time.deltaTime * 10);
        }

        if (_isFirstPerson)
        {
            if (Input.GetButton(_horizontalinput) && Input.GetAxis(_horizontalinput) > 0)
                transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0f);

            if (Input.GetButton(_horizontalinput) && Input.GetAxis(_horizontalinput) < 0)
                transform.Rotate(0, -_rotationSpeed * Time.deltaTime, 0f);

            if (Input.GetButton(_verticalinput) && Input.GetAxis(_verticalinput) < 0)
                transform.Rotate(_rotationSpeed * Time.deltaTime, 0, 0f);

            if (Input.GetButton(_verticalinput) && Input.GetAxis(_verticalinput) > 0)
                transform.Rotate(-_rotationSpeed * Time.deltaTime, 0, 0f);
        }
    }
}