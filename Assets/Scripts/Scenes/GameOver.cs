using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Main sahnesindeki GameOver objesine referans
    private GameObject gameOverObject;

    private void Start()
    {
        // Main sahnesinde "GameOver" adında bir objeyi bulur
        gameOverObject = GameObject.Find("GameOver");

        // Objeyi başlangıçta deaktif yapar
        if (gameOverObject != null)
        {
            gameOverObject.SetActive(false);
        }
        else
        {
            Debug.LogError("GameOver object not found in the scene.");
        }
    }

    public void GameOverButton()
    {

        // GameOver objesini aktif hale getirir
        if (gameOverObject != null)
        {
            gameOverObject.SetActive(true);
        }
        else
        {
            Debug.LogError("GameOver object reference is null.");
        }
        
  

    }
}