//App
using RENEGADES.Common;
using RENEGADES.Gameplay.Players;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.AI
{
    public class AttackingState : IEnemyState
    {
        private readonly Enemy enemy;

        //Every 0.2f seconds the enemy will quickly determine what enemy they want to attack
        //This is used to save performance on searching for hot spots
        private float FindPlayerTimer;
        private const float WANDER = 0.2f;

        private float speed;
        private Rigidbody2D enemyRigidBody;

        private Player playerToGoAfter;

        public AttackingState (Enemy enemy)
        {
            this.enemy = enemy;
            enemyRigidBody = enemy.EnemyRigidBody;
            playerToGoAfter = FindClosest.Find<Player>(enemy.transform);
        }

        public void UpdateState()
        {
            if (enemy.Attributes.HEALTH <= 0) ToDeadState();
            enemy._EnemyAnimator.SetAnimState(Constants.AnimationTriggers.EnemyAnimation.Attack);
            Turning();
            CheckProximity();
        }

        public void ToWalkState()
        {
            enemy.CurrentState = enemy._WalkingState;
        }

        public void ToAttackState()
        {
            //This is the attacking state!
        }

        public void ToDeadState()
        {
            enemy.CurrentState = enemy._DeadState;
        }

        private void Turning()
        {
            FindPlayerTimer += Time.deltaTime;
            if (FindPlayerTimer > WANDER)
            {
                FindPlayerTimer = 0;
                playerToGoAfter = FindClosest.Find<Player>(enemy.transform);
            }
            Vector3 moveDirection = enemy.GetPosition() - playerToGoAfter.GetPosition();
            float viewAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90;
            enemy.SetRotation(Quaternion.AngleAxis(viewAngle, Vector3.forward));
        }

        private void CheckProximity()
        {
            if (Vector3.Distance(enemy.GetPosition(), playerToGoAfter.GetPosition()) > enemy.Attributes.ATTACK_RANGE)
            {
                ToWalkState();
            }
        }

    }
}
