using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetButton("Fire1"))
        {
            LoadScene("Luke");
        }	
	}

    public void LoadScene(string name)
    {
        Debug.Log("scene load" + name);
        SceneManager.LoadScene(name);
    }
}
