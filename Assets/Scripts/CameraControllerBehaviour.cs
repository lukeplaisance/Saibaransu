using UnityEngine;

//feedback:
//if you ever have two scripts that are copy pasted, you can merge them somehow
//get someone to review


public class CameraControllerBehaviour : MonoBehaviour
{

    [Header("Input Values")]
    [SerializeField]
    private string _horizontalinput = "P1Horizontal";
    [SerializeField]
    private string _verticalinput = "P1Vertical";
    [SerializeField]
    private string _fireinput1 = "P1Fire2";
    [SerializeField]
    private string _fireinput2 = "P1Fire1";

    [Header("Events")]
    [SerializeField]
    private GameEvent InputFire1;
    [SerializeField]
    private GameEvent InputFire2;
    

    [SerializeField]
    private GameEvent OnFirstPersonSwitch;


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
        _camera = GetComponent<Camera>();

    }
    
    private void Update()
    {
        if (Input.GetButtonDown(_fireinput1))
        {
            InputFire1.Raise();
        }

        if (Input.GetButtonDown(_fireinput2))
        {
            InputFire2.Raise();
        }

        //ToDo: make a vector for rotation and change that
        if (Input.GetAxis(_horizontalinput) > 0)
            _camera.transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0f);

        if (Input.GetAxis(_horizontalinput) < 0)
            _camera.transform.Rotate(0, -_rotationSpeed * Time.deltaTime, 0f);

        if (Input.GetAxis(_verticalinput) < 0)
            _camera.transform.Rotate(_rotationSpeed * Time.deltaTime, 0, 0f);

        if (Input.GetAxis(_verticalinput) > 0)
            _camera.transform.Rotate(-_rotationSpeed * Time.deltaTime, 0, 0f);

    }
}