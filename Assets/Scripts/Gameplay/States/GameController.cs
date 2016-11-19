//Unity
using UnityEngine;


namespace RENEGADES.Gameplay.States
{
    /// <summary>
    /// Main Game Controller to determine states of game
    /// </summary>
    public class GameController : MonoBehaviour
    {
        private IGameState CurrentState;
        private RechargeState rechargeState;
        private BattleState battleState;
        private GameOverState gameOverState;

        private void Awake()
        {
            CreateStates();
        }

        private void CreateStates()
        {
            rechargeState = new RechargeState(this);
            battleState = new BattleState(this);
            gameOverState = new GameOverState(this);
            CurrentState = rechargeState;
        }

        private void Update()
        {
            CurrentState.OnUpdate();
        }

        public void ToRecharge()
        {
            CurrentState = rechargeState;
        }

        public void ToBattle()
        {
            CurrentState = battleState;
        }

        public void ToGameOver()
        {
            CurrentState = gameOverState;
        }

    }
}
