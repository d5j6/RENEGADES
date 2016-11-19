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

        public void Battle()
        {
            //Will never get called
        }

        public void GameOver()
        {
            gameController.ToGameOver();
        }

        public void Recharge()
        {
            gameController.ToRecharge();
        }

        public void OnUpdate()
        {

        }

    }
}
