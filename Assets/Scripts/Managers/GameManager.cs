//App
using RENEGADES.Common;
using RENEGADES.Audio;
using RENEGADES.Gameplay.PlayerInput;

//Unity
using UnityEngine;


namespace RENEGADES.Managers
{
    //singleton game manager
    public class GameManager : Singleton<GameManager>
    {
        private ControllerManager controllerManager;
        public ControllerManager ControllerManager
        {
            get { return controllerManager ?? (controllerManager = GetComponent<ControllerManager>()); }
        }

        private LevelLoader levelLoader;
        public LevelLoader LevelLoader
        {
            get { return levelLoader ?? (levelLoader = GetComponent<LevelLoader>()); }
        }

        private BaseSoundController audioManager;
        public BaseSoundController AudioManager
        {
            get { return audioManager ?? (audioManager = FindObjectOfType<BaseSoundController>()); }
        }

        private void Awake()
        {
            DontDestroyOnLoad(transform.gameObject); //Dont Destroy on Load
        }

        private void OnDestroy()
        {
            controllerManager = null;
            levelLoader = null;
        }
    }
}
