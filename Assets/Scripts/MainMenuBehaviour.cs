using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour
{
    public string GamePlayScene;
    public GameObject MainMenuObject;
    public GameObject CreditsObject;

    public void StartGame()
    {
        SceneManager.LoadScene(GamePlayScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ToggleCredits()
    {
        MainMenuObject.SetActive(!MainMenuObject.activeSelf);
        CreditsObject.SetActive(!MainMenuObject.activeSelf);
    }
}
