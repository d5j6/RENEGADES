//App
using RENEGADES.Common;
using RENEGADES.Gameplay.Basic;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.AI
{
    public class AttackingState : IEnemyState
    {
        private readonly MonsterAI monster;

        //Every 0.2f seconds the enemy will quickly determine what enemy they want to attack
        //This is used to save performance on searching for hot spots
        private float FindPlayerTimer;
        private const float WANDER = 3f;

        private float attackTimer = 0;

        private float speed;

        private Friendly ObjectToChase;

        public AttackingState (MonsterAI enemy)
        {
            monster = enemy;
            ObjectToChase = FindClosest.Find<Friendly>(enemy.transform);
        }

        public void SetUp()
        {
            Debug.Log("ATTACKING");
            attackTimer = 0;
            monster._EnemyAnimator.SetAnimState(Constants.AnimationTriggers.EnemyAnimation.Attack);
        }

        public void UpdateState()
        {
            if (monster.HEALTH <= 0) ToDeadState();
            Turning();
            CheckProximity();
            DamageTimer();
        }

        public void ToWalkState()
        {
            
            monster.CurrentState = monster._WalkingState;
            monster.CurrentState.SetUp();
        }

        public void ToAttackState()
        {
            //This is the attacking state!
        }

        public void ToDeadState()
        {
            monster.CurrentState = monster._DeadState;
        }

        private void Turning()
        {
            FindPlayerTimer += Time.deltaTime;
            if (FindPlayerTimer > WANDER)
            {
                FindPlayerTimer = 0;
                ObjectToChase = FindClosest.Find<Friendly>(monster.transform);
            }
            Vector3 moveDirection = monster.GetPosition() - ObjectToChase.GetPosition();
            float viewAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90;
            monster.SetRotation(Quaternion.AngleAxis(viewAngle, Vector3.forward));
        }

        private void CheckProximity()
        {
            Vector3 raycastDir = ObjectToChase.GetPosition() - monster.GetPosition();
            RaycastHit2D hit = Physics2D.Raycast(monster.GetPosition(), raycastDir, Mathf.Infinity, ObjectToChase.GetLayer());
            Debug.Log(hit.transform.name);
            if (hit.distance > monster._Attributes.ATTACK_RANGE)
            {
                ToWalkState();
            }
        }

        private void DamageTimer()
        {
            attackTimer += Time.deltaTime;
            if(attackTimer > monster._Attributes.ATTACK_SPEED)
            {
                ObjectToChase.UpdateHealth(-monster._Attributes.DAMAGE);
                attackTimer = 0; //reset attack
            }
        }
    }
}
