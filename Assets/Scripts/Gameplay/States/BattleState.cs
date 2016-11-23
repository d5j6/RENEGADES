//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.States
{

    public class BattleState : IGameState
    {
        private GameController gameController;

        public BattleState(GameController controller)
        {
            gameController = controller;
        }

        /// <summary>
        /// Called on State Start
        /// </summary>
        public void Begin()
        {
          
        }

        public void Battle()
        {
            //Will never get called
        }

        public void GameOver()
        {
            gameController.Change_State(gameController._GameOverState);
        }

        public void Recharge()
        {
            gameController.Change_State(gameController._RechargeState);
        }

        public void OnUpdate()
        {
            if (gameController.GameOver()) { GameOver(); return; }
        }

    }
}
