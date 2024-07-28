using UnityEngine;

namespace Components
{
    public class DestroyNoise : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip destroySoundClip; // Eşleşme ses efekti

        private void Start()
        {
            if (audioSource == null)
            {
                Debug.LogError("AudioSource bileşeni atanmadı!");
            }
            if (destroySoundClip == null)
            {
                Debug.LogError("Destroy ses klibi atanmadı!");
            }
        }

        public void PlayDestroySound()
        {
            if (audioSource != null && destroySoundClip != null)
            {
                audioSource.clip = destroySoundClip;
                audioSource.Play();
                Debug.Log($"Playing destroy sound clip: {destroySoundClip.name}");
            }
            else
            {
                Debug.LogError("Ses kaynağı veya klip eksik!");
            }
        }
    }
}