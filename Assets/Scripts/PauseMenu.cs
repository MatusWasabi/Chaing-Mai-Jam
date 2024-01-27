using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject uiElements;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            uiElements.SetActive(!uiElements.activeInHierarchy);
        }
    }

    public void PauseGame()
    {
        uiElements.SetActive(true);
    }

    public void Resume()
    {
        uiElements.SetActive(false);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
