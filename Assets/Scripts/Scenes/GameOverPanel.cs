using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void RestartGame()
    {
        Time.timeScale = 1; 
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Debug.Log("Game restarted");
    }

    public void Login()
    {
         Time.timeScale = 1;
        SceneManager.LoadScene("Login");
        Debug.Log("Main menu called");
    }
    

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}