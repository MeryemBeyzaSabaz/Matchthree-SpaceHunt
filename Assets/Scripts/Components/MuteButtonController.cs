using UnityEngine;
using UnityEngine.UI;

public class MuteButtonController : MonoBehaviour
{
    [SerializeField] private Button muteButton;
    [SerializeField] private AudioSource audioSource;

    private bool isMuted = false;

    private void Start()
    {
        if (muteButton != null)
        {
            muteButton.onClick.AddListener(ToggleMute);
        }
        else
        {
            Debug.LogError("Mute button is not assigned!");
        }

        if (audioSource == null)
        {
            Debug.LogError("AudioSource is not assigned!");
        }
    }

    private void ToggleMute()
    {
        if (audioSource != null)
        {
            isMuted = !isMuted;
            audioSource.mute = isMuted;
    
        }
    }

  
}