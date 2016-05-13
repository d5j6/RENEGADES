//Unity
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RENEGADES.UI.Managers
{
    public class MainMenuManager : MonoBehaviour
    {
        public void LAUNCHGAME()
        {
            SceneManager.LoadScene(1);
        }

    }
}
