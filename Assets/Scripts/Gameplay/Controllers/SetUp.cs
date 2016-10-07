//App
using RENEGADES.Gameplay.Players;
using RENEGADES.UI.Gameplay;
using RENEGADES.Managers;

//Unity
using UnityEngine;

//C#
using System.Collections.Generic;
using System.Linq;

namespace RENEGADES.Gameplay.Controllers
{
    /// <summary>
    /// Used to setup the start of a game
    /// </summary>
    public class SetUp : Spawner
    {
        [Header("Player Prefab")]
        [Tooltip("Prefab for a Player")]
        public Player playerPrefab;

        private List<Player> players;
        private List<Player> Players
        {
            get { return players ?? (players = FindObjectsOfType<Player>().ToList()); }
        }

        public override void Init()
        {
            SetUpPlayers();
        }

        private void SetUpPlayers()
        {
            //spawns a default player
            if (Players.Count == 0)
            {
                CreatePlayer();
            }
            //spawns the rest of the players based on if there are more than one controller
            if(GameManager.Instance._ControllerManager.GetControllerCount() > 1)
            {
                for(int i=1; i < GameManager.Instance._ControllerManager.GetControllerCount(); i++)
                {
                    CreatePlayer();
                }
            }
        }

        private void CreatePlayer()
        {
            Player newPlayer = Spawn(playerPrefab);
            Players.Add(newPlayer);
            GameManager.Instance.EffectSpawner.CreateEffect(Effects.EffectType.Spawn, newPlayer.GetPosition());
            PlayerModule hud = GameManager.Instance.UISpawner.CreateWidget(UI.Managers.WidgetCreator.WidgetToSpawn.PlayerModule) as PlayerModule;
            newPlayer.PlayerHUD = hud;

        }


        private void OnDestroy()
        {
            players = null;
        }


    }
}
