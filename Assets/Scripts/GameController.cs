using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public BikeManager BikeOne;
    public BikeManager BikeTwo;
    public GameObject CameraOne;
    public GameObject CameraTwo;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetButton("Fire1"))
        {
            SceneManager.LoadScene("Luke");
        }	
	}
}
