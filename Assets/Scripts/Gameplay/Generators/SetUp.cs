//App
using RENEGADES.Gameplay.Players;
using RENEGADES.UI.Gameplay;
using RENEGADES.Managers;
using RENEGADES.Gameplay.States;

//Unity
using UnityEngine;

//C#

namespace RENEGADES.Gameplay.Generators
{
    /// <summary>
    /// Used to setup the start of a game
    /// </summary>
    public class SetUp : Spawner
    {
        [Header("Player Prefab")]
        [Tooltip("Prefab for Players")]
        public Player Assault;
        public Player Engineer;

        private GameController gameController;
        private GameController _GameController
        {
            get { return gameController ?? (gameController = GetComponent<GameController>()); }
        }


        public override void Init()
        {
            SetUpPlayers();
            _GameController.BEGIN(); //begin game
        }

        private void SetUpPlayers()
        {
            foreach(var P in GameManager.Instance._GameSettings.GetPlayers())
            {
                CreatePlayer(P.Key,P.Value);
            }
        }

        /// <summary>
        /// Create all players based on game setting player dictionary
        /// </summary>
        /// <param name="playerNumber"></param>
        /// <param name="type"></param>
        private void CreatePlayer(int playerNumber,GameSettings.PlayerType type)
        {
            Player newPlayer = Spawn(( type == GameSettings.PlayerType.Assault) ? Assault : Engineer);
            newPlayer.SetPlayerNumber(playerNumber);
            GameManager.Instance.EffectSpawner.CreateEffect(EffectBlueprint.EffectType.Spawn, newPlayer.GetPosition());
            PlayerModule hud = GameManager.Instance.UISpawner.CreateWidget(UI.Managers.WidgetCreator.WidgetToSpawn.PlayerModule) as PlayerModule;
            hud.SetContent(playerNumber,type);
            newPlayer.PlayerHUD = hud;
        }


        private void OnDestroy()
        {

        }


    }
}
