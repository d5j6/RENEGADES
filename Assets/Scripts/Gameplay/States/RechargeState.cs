

namespace RENEGADES.Gameplay.States
{
    public class RechargeState : IGameState
    {
        private GameController gameController;

        public RechargeState(GameController controller)
        {
            gameController = controller;
        }

        public void Battle()
        {
            gameController.ToBattle();
        }

        public void GameOver()
        {
            gameController.ToGameOver();
        }

        public void Recharge()
        {
            //Will never get called
        }

        public void OnUpdate()
        {
           
        }


    }
}
