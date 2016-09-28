//App
using RENEGADES.Gameplay.Basic;
using RENEGADES.Common;
using RENEGADES.Gameplay.Players;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.AI
{

    public class WalkingState : IEnemyState
    {

        private readonly Enemy enemy;

        //Every 0.5f seconds the enemy will quickly determine what they want to go after
        //This is used to save performance on searching for hot spots
        private float FindPlayerTimer;
        private const float WANDER = 0.5f;

        private float speed;
        private Rigidbody2D enemyRigidBody;

        private Damageable ObjectToChase;

        public WalkingState(Enemy enemy)
        {
            this.enemy = enemy;
            speed = enemy.Attributes.SPEED;
            enemyRigidBody = enemy.EnemyRigidBody;
            ObjectToChase = FindClosest.Find<Damageable>(enemy.transform);
        }

        public void UpdateState()
        {
            if (enemy.Attributes.HEALTH <= 0) ToDeadState();
            enemy._EnemyAnimator.SetAnimState(Constants.AnimationTriggers.EnemyAnimation.Walk);
            Movement();
            CheckProximity();
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

        private void CheckProximity()
        {
            RaycastHit2D hit = Physics2D.Raycast(enemy.GetPosition(), -enemy.transform.up);
            if (Vector3.Distance(enemy.GetPosition(), ObjectToChase.GetPosition()) < enemy.Attributes.ATTACK_RANGE)
            {
                ToAttackState();
            }
        }

        private void Movement()
        {
            FindPlayerTimer += Time.deltaTime;
            if(FindPlayerTimer > WANDER)
            {
                FindPlayerTimer = 0;
                ObjectToChase = FindClosest.Find<Damageable>(enemy.transform);
            }   
            TurnTowards(ObjectToChase.GetPosition());
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
            enemyRigidBody.AddForce(-enemy.transform.up * speed);
            enemyRigidBody.velocity = Vector3.ClampMagnitude(enemyRigidBody.velocity, speed);
        }
    }
}
