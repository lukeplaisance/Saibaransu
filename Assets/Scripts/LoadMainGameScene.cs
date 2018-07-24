using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainGameScene : MonoBehaviour
{
    public void OnButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
