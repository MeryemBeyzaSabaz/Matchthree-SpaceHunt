using Events;
using Extensions.Unity.MonoHelper;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Zenject;

public class GameController : EventListenerMono
{
    [Inject] private PlayerEvents PlayerEvents { get; set; }
    [SerializeField] private int targetScore = 100;
    public GameObject endOfLevel1;
    public Button nextLevelButton;
    public TextMeshProUGUI endOfLevel1Text;
    [SerializeField] private string _endLevelMessage = "Tebrikler! 100 puana ulaştınız!";

    void Start()
    {
        endOfLevel1.SetActive(false);
        nextLevelButton.onClick.AddListener(LoadNextLevel);
    }

    void EndGame()
    {
        Debug.Log("EndGame called");
        Time.timeScale = 0; 
        endOfLevel1.SetActive(true);
        endOfLevel1Text.text = _endLevelMessage;
    }

    void LoadNextLevel()
    {
        Time.timeScale = 1; 
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Debug.Log("LoadLevel2 called.");
    }
    
    

    protected override void RegisterEvents()
    {
        PlayerEvents.ScoreUpdate += OnScoreUpdate;
    }

    private void OnScoreUpdate(int arg0)
    {
        if (arg0 >= targetScore)
        {
            EndGame();
            PlayerEvents.LevelComplete?.Invoke();
        }
    }

    protected override void UnRegisterEvents()
    {
        PlayerEvents.ScoreUpdate -= OnScoreUpdate;
    }
}