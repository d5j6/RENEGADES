//App
using RENEGADES.Common;
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
