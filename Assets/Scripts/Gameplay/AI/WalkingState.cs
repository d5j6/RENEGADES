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

        public WalkingState(Enemy enemy)
        {
            this.enemy = enemy;
        }

        public void UpdateState()
        {
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

        private void Movement()
        {
            Vector3 playerPosition = FindClosest.Find<Player>(enemy.transform).transform.position;
            TurnTowards(playerPosition);
            MoveTowards(playerPosition);
        }

        private void TurnTowards(Vector3 playerPosition)
        {
            Vector3 moveDirection = enemy.GetPosition() - playerPosition;
            float viewAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90;
            enemy.SetRotation(Quaternion.AngleAxis(viewAngle, Vector3.forward));

        }

        private void MoveTowards(Vector3 playerPosition)
        {
            enemy.MOVE(0);
        }
    }
}
