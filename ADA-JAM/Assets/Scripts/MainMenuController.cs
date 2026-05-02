using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Scene Settings")]
    public string gameSceneName = "MainScene";

    [Header("Panels")]
    public GameObject instructionsPanel;

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void OpenInstructions()
    {
        if (instructionsPanel != null)
        {
            instructionsPanel.SetActive(true);
        }
        else
        {
            Debug.Log("Instructions button pressed");
        }
    }

    public void CloseInstructions()
    {
        if (instructionsPanel != null)
        {
            instructionsPanel.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit button pressed");
        Application.Quit();
    }
}   