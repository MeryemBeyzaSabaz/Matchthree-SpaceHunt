using UnityEngine;
using UnityEngine.UI;

namespace Components
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance { get; private set; }
        
        [SerializeField] private AudioSource mainAudioSource; // Genel AudioSource
        [SerializeField] private AudioClip backgroundMusicClip; // Başlangıç müziği
       

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                mainAudioSource = GetComponent<AudioSource>();

                if (mainAudioSource == null)
                {
                    mainAudioSource = gameObject.AddComponent<AudioSource>();
                }

                // Başlangıç müziğini başlat
                if (backgroundMusicClip != null)
                {
                    mainAudioSource.clip = backgroundMusicClip;
                    mainAudioSource.loop = true; // Müzik sürekli çalacak
                    mainAudioSource.Play();
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }

        
    }
}
