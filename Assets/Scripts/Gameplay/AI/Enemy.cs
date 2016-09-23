//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.AI
{
    public class Enemy : MonoBehaviour
    {
        private IEnemyState currentState;
        public IEnemyState CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }

        private AttackingState attackingState;
        public AttackingState _AttackingState
        {
            get { return attackingState; }
            set { attackingState = value; }
        }

        private WalkingState walkingState;
        public WalkingState _WalkingState
        {
            get { return walkingState; }
            set { walkingState = value; }
        }

        private void Awake()
        {
            attackingState = new AttackingState(this);
            walkingState = new WalkingState(this);
        }

        private void Update()
        {
            currentState.UpdateState();
        }

    }
}
