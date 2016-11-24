//Unity
using UnityEngine;

//Game
using RENEGADES.UI.InGame.PopUps;
using RENEGADES.Managers;

namespace RENEGADES.Gameplay.States
{

    public class GameOverState : IGameState
    {

        private GameController gameController;

        private float resetTime = 0;
        private float resetTimer = 0;

        public GameOverState(GameController controller)
        {
            gameController = controller;
        }

        /// <summary>
        /// Called on State Start
        /// </summary>
        public void Begin()
        {
            GameManager.Instance.UISpawner.CreateWidget(UI.Managers.WidgetCreator.WidgetToSpawn.GameOverText); //spawn game over text
            resetTime = gameController.GetBluePrint().GetGameOverTime();
        }

        public void Battle()
        {
            //once the games over you go back to the main menu
        }

        public void GameOver()
        {
            //once the games over you go back to the main menu
        }

        public void Recharge()
        {
            //once the games over you go back to the main menu
        }

        public void OnUpdate()
        {
            resetTimer += Time.deltaTime;
            if(resetTimer > resetTime)
            {
                LOADMAIN();
            }
        }

        private void LOADMAIN()
        {
            GameManager.Instance._LevelLoad.LoadLevel(LevelLoader.Levels.MainMenu);
        }


    }
}
