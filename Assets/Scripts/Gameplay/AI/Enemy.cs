//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.AI
{
    [RequireComponent(typeof(Rigidbody2D))]
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

        private Rigidbody2D rigid;
        private Rigidbody2D EnemyRigidBody
        {
            get { return rigid ?? (rigid = GetComponent<Rigidbody2D>()); }
        }

        private void Awake()
        {
            attackingState = new AttackingState(this);
            walkingState = new WalkingState(this);
            currentState = walkingState;
        }

        private void Update()
        {
            currentState.UpdateState();
        }

        //returns position
        public Vector3 GetPosition()
        {
            return transform.position;
        }

        /// <summary>
        /// Set rotation of enemy
        /// </summary>
        public void SetRotation(Quaternion q)
        {
            transform.rotation = q;
        }

        // Set Position
        public virtual void MOVE(float SPEED)
        {
            EnemyRigidBody.AddForce(-transform.up * SPEED);
            EnemyRigidBody.velocity = Vector3.ClampMagnitude(EnemyRigidBody.velocity, SPEED);
        }
    }
}
