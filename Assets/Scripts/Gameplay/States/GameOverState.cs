//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.States
{

    public class GameOverState : IGameState
    {

        private GameController gameController;

        public GameOverState(GameController controller)
        {
            gameController = controller;
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

        }


    }
}
