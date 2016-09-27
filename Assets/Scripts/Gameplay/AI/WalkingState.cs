//App
using RENEGADES.Common;
using RENEGADES.Gameplay.Players;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.AI
{

    public class WalkingState : IEnemyState
    {

        private readonly Enemy enemy;

        private Vector3 playerPosition;

        //Every 0.5f seconds the enemy will quickly determine what they want to go after
        //This is used to save performance on searching for hot spots
        private float FindPlayerTimer;
        private const float WANDER = 0.5f;

        public WalkingState(Enemy enemy)
        {
            this.enemy = enemy;
        }

        public void UpdateState()
        {
            if (enemy.HEALTH <= 0) ToDeadState();
            Movement();
        }

        public void ToWalkState()
        {
            //We are already walking
        }

        public void ToAttackState()
        {
            enemy.CurrentState = enemy._AttackingState;
        }

        public void ToDeadState()
        {
            enemy.CurrentState = enemy._DeadState;
        }

        private void Movement()
        {
            FindPlayerTimer += Time.deltaTime;
            if(FindPlayerTimer > WANDER)
            {
                FindPlayerTimer = 0;
                playerPosition = FindClosest.Find<Player>(enemy.transform).transform.position;
            }   
            TurnTowards(playerPosition);
            MoveTowards();
        }

        private void TurnTowards(Vector3 playerPosition)
        {
            Vector3 moveDirection = enemy.GetPosition() - playerPosition;
            float viewAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90;
            enemy.SetRotation(Quaternion.AngleAxis(viewAngle, Vector3.forward));

        }

        private void MoveTowards()
        {
            enemy.MOVE(0);
        }
    }
}
