using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonControls : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
