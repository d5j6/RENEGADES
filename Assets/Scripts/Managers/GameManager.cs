﻿//App
using RENEGADES.Common;
using RENEGADES.Audio;
using RENEGADES.Gameplay.PlayerInput;
using RENEGADES.Gameplay.Controllers;

//Unity


namespace RENEGADES.Managers
{
    //singleton game manager
    public class GameManager : Singleton<GameManager>
    {
        private ControllerManager controllerManager;
        public ControllerManager _ControllerManager
        {
            get { return controllerManager ?? (controllerManager = GetComponent<ControllerManager>()); }
        }

        private LevelLoader levelLoader;
        public LevelLoader _LevelLoad
        {
            get { return levelLoader ?? (levelLoader = GetComponent<LevelLoader>()); }
        }

        private BaseSoundController audioManager;
        public BaseSoundController AudioManager
        {
            get { return audioManager ?? (audioManager = FindObjectOfType<BaseSoundController>()); }
        }

        private Effects effectSpawner;
        public Effects EffectSpawner
        {
            get { return effectSpawner ?? (effectSpawner = FindObjectOfType<Effects>()); }
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
