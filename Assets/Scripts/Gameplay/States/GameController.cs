//Unity
using UnityEngine;

//Game
using RENEGADES.Gameplay.Props;


namespace RENEGADES.Gameplay.States
{
    /// <summary>
    /// Main Game Controller to determine states of game
    /// </summary>
    public class GameController : MonoBehaviour
    {
        /// <summary>
        /// gameplay state interface
        /// </summary>
        private IGameState CurrentState;

        /// <summary>
        /// Recharge gameplay state
        /// </summary>
        /// 
        private RechargeState rechargeState;
        public RechargeState _RechargeState { get { return rechargeState; } }

        /// <summary>
        /// Battle Gameplay state
        /// </summary>
        private BattleState battleState;
        public BattleState _BattleState { get { return battleState; } }

        /// <summary>
        /// Game over gameplay state
        /// </summary>
        private GameOverState gameOverState;
        public GameOverState _GameOverState { get { return gameOverState; } }

        private Tower ourTower;
        private Tower OurTower
        {
             get { return ourTower = FindObjectOfType<Tower>(); }
        }

        private RoundBlueprint _RoundBlueprint = new RoundBlueprint();

        public void BEGIN()
        {
            CreateStates();
        }

        private void CreateStates()
        {
            rechargeState = new RechargeState(this);
            battleState = new BattleState(this);
            gameOverState = new GameOverState(this);
            Change_State(rechargeState);
        }

        private void Update()
        {
            CurrentState.OnUpdate();
        }

        public void Change_State(IGameState state)
        {
            CurrentState = state;
            CurrentState.Begin();
        }

        public RoundBlueprint GetBluePrint()
        {
            return _RoundBlueprint;
        }

        /// <summary>
        /// Returns true if at least one player is alive and tower is alive
        /// </summary>
        /// <returns></returns>
        public bool GameOver()
        {
            if (OurTower == null) return true;
            return false;
        }



        /// <summary>
        /// Remove
        /// </summary>
        private void OnDestroy()
        {
            _RoundBlueprint = null;
            rechargeState = null;
            battleState = null;
            gameOverState = null;
            CurrentState = null;
        }

    }
}
