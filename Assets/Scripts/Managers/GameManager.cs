//App
using RENEGADES.Common;
using RENEGADES.Audio;
using RENEGADES.Gameplay.Joysticks;
using RENEGADES.Gameplay.Generators;
using RENEGADES.Gameplay.Items;
using RENEGADES.Gameplay.Effects;
using RENEGADES.UI.Managers;
using RENEGADES.UI.MainMenu;

//Unity


namespace RENEGADES.Managers
{
    //singleton game manager
    public class GameManager : Singleton<GameManager>
    {
        private GameSettings gameSettings;
        public GameSettings _GameSettings
        {
            get { return gameSettings ?? (gameSettings = FindObjectOfType<GameSettings>()); }
        }

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

        private MainMenuController mainMenu;
        public  MainMenuController MainMenu
        {
            get { return mainMenu ?? (mainMenu = FindObjectOfType<MainMenuController>()); }
        }

        private BaseSoundController audioManager;
        public BaseSoundController AudioManager
        {
            get { return audioManager ?? (audioManager = FindObjectOfType<BaseSoundController>()); }
        }

        private EnemyGenerator monsterSpawner;
        public EnemyGenerator MonsterSpawner
        {
            get { return monsterSpawner ?? (monsterSpawner = FindObjectOfType<EnemyGenerator>()); }
        }

        private EffectGenerator effectSpawner;
        public EffectGenerator EffectSpawner
        {
            get { return effectSpawner ?? (effectSpawner = FindObjectOfType<EffectGenerator>()); }
        }

        private WidgetCreator uiSpawner;
        public WidgetCreator UISpawner
        {
            get { return uiSpawner ?? (uiSpawner = FindObjectOfType<WidgetCreator>()); }
        }

        private ItemGenerator itemSpawner;
        public ItemGenerator ItemSpawner
        {
            get { return itemSpawner ?? (itemSpawner = FindObjectOfType<ItemGenerator>()); }
        }

        private TurretGenerator turretSpawner;
        public TurretGenerator TurretSpawner
        {
            get { return turretSpawner ?? (turretSpawner = FindObjectOfType<TurretGenerator>()); }
        }


        private void Awake()
        {
            DontDestroyOnLoad(transform.gameObject); //Dont Destroy on Load
        }


        /// <summary>
        /// Called when a new scene is loaded to fresh references to Managers that are not DontDestroyOnLoad Gameobjects
        /// </summary>
        public void REFRESH()
        {
            mainMenu = null;
            audioManager = null;
            monsterSpawner = null;
            effectSpawner = null;
            uiSpawner = null;
            itemSpawner = null;
            turretSpawner = null;
        }

        private void OnDestroy()
        {
            controllerManager = null;
            levelLoader = null;
        }
    }
}
