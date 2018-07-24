using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuBehaviour : MonoBehaviour
{
    public string GameScene;
    public GameObject ButtonObject;

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(GameScene);
    }
}
