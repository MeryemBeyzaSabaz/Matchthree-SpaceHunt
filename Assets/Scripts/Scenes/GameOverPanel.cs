using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public GameObject gameOverPanel;

    private void Start()
    {
        if (gameOverPanel == null)
        {
            Debug.LogError("GameOverPanel is not assigned.");
        }
    }

    public void RestartGame()
    {
        if (gameOverPanel != null)
        {
            Time.timeScale = 1; 
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        
            Debug.Log("Game restarted");
        }
        else
        {
            Debug.LogError("GameOverPanel is not assigned.");
        }
    }

    public void LoginMenu()
    {
        SceneManager.LoadScene("Login");
        Debug.Log("Main menu called");
    }
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}