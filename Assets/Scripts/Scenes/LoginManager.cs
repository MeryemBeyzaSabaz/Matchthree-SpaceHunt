using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class LoginManager : MonoBehaviour
    {
        public void LoadLoginScene()
        {
            SceneManager.LoadScene("Login");
        }
    }

}