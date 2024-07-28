using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
 public void PlayGame()
 {
  SceneManager.LoadScene("Scenes/Main");
  
 }


 public void QuitGame()
 {
  Application.Quit();
  Debug.Log("Game closed");
 }
}
