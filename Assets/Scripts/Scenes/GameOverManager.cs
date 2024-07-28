using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    private void Start()
    {
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {

        SceneManager.LoadScene("Main");

       
        SceneManager.LoadScene("Main");
        Debug.Log("Game restarted");

    }

    public void LoadMainMenu()
    {

        SceneManager.LoadScene("Login");

       
        SceneManager.LoadScene("Login");
        Debug.Log("Main menu called");

    }
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}