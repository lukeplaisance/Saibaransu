using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public void OnStartGame()
    {
        Debug.Log("pressed start game");
        SceneManager.LoadScene("Luke");
    }
}
