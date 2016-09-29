//App
using RENEGADES.Common;
using RENEGADES.Gameplay.Basic;

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
        private const float WANDER = 3f;

        private float speed;

        private Damageable ObjectToChase;

        public AttackingState (Enemy enemy)
        {
            this.enemy = enemy;
            ObjectToChase = FindClosest.Find<Damageable>(enemy.transform);
        }

        public void SetUp()
        {
            Debug.Log("SETUP");
            enemy._EnemyAnimator.SetAnimState(Constants.AnimationTriggers.EnemyAnimation.Attack);
        }

        public void UpdateState()
        {
            
            if (enemy.Attributes.HEALTH <= 0) ToDeadState();
            Turning();
            CheckProximity();
        }

        public void ToWalkState()
        {
            
            enemy.CurrentState = enemy._WalkingState;
            enemy.CurrentState.SetUp();
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
                ObjectToChase = FindClosest.Find<Damageable>(enemy.transform);
            }
            Vector3 moveDirection = enemy.GetPosition() - ObjectToChase.GetPosition();
            float viewAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90;
            enemy.SetRotation(Quaternion.AngleAxis(viewAngle, Vector3.forward));
        }

        private void CheckProximity()
        {
            Vector3 raycastDir = ObjectToChase.GetPosition() - enemy.GetPosition();
            RaycastHit2D hit = Physics2D.Raycast(enemy.GetPosition(), raycastDir, Mathf.Infinity, ObjectToChase.GetLayer());
            if (hit.distance > enemy.Attributes.ATTACK_RANGE)
            {
                ToWalkState();
            }
        }

    }
}
