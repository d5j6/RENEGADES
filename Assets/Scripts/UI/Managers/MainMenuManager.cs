//App
using RENEGADES.Managers;

//Unity
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RENEGADES.UI.Managers
{
    public class MainMenuManager : MonoBehaviour
    {
        public void LAUNCHGAME()
        {
            GameManager.Instance._LevelLoad.LoadLevel(LevelLoader.Levels.Game);
        }

        private void Update()
        {
            if(Input.anyKey) LAUNCHGAME();
        }

    }
}
