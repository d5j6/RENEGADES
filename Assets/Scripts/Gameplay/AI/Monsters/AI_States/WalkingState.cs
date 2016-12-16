//App
using RENEGADES.Gameplay.Basic;
using RENEGADES.Common.Gameplay;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.AI.Monsters
{

    public class WalkingState : IEnemyState
    {

        private readonly MonsterAI monster;

        //Every 0.5f seconds the enemy will quickly determine what they want to go after
        //This is used to save performance on searching for hot spots
        private float FindPlayerTimer;
        private const float WANDER = 0.5f;


        private Friendly ObjectToChase;

        public WalkingState(MonsterAI enemy)
        {
            monster = enemy;
        }

        public void SetUp()
        {
            monster._EnemyAnimator.SetAnimState(Constants.AnimationTriggers.EnemyAnimation.Walk);
        }

        public void UpdateState()
        {
            if (monster.HEALTH <= 0) { ToDeadState(); return; }
            Movement();
            CheckProximity();
        }

        public void ToWalkState()
        {
            //We are already walking
        }

        public void ToAttackState()
        {
            
            monster.CurrentState = monster._AttackingState;
            monster.CurrentState.SetUp();
        }

        public void ToDeadState()
        {
            monster.CurrentState = monster._DeadState;
        }

        private void CheckProximity()
        {

            if (ObjectToChase == null) FindObjectToChase();
            Vector3 raycastDir = (ObjectToChase.GetPosition()) - monster.GetPosition();
            RaycastHit2D hit = Physics2D.Raycast(monster.GetPosition(), raycastDir, Mathf.Infinity, ObjectToChase.GetLayer());
            if (hit.distance < monster.blueprint.attackRange)
            {
                ToAttackState();
            }
        }

        private void Movement()
        {

            if (ObjectToChase == null) FindObjectToChase();
            FindPlayerTimer += Time.deltaTime;
            if(FindPlayerTimer > WANDER)
            {
                FindPlayerTimer = 0;
                FindObjectToChase();
            }   
            TurnTowards(ObjectToChase.GetPosition());
            MoveTowards(ObjectToChase.GetPosition());
        }

        private void TurnTowards(Vector3 playerPosition)
        {
            Vector3 moveDirection = monster.GetPosition() - playerPosition;
            float viewAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90;
            monster.SetRotation(Quaternion.AngleAxis(viewAngle, Vector3.forward));

        }

        private void MoveTowards(Vector3 pos)
        {
            monster.transform.position += -monster.transform.up* Time.smoothDeltaTime * monster.blueprint.speed;
        }

        /// <summary>
        /// Find something for this bastard to go after
        /// </summary>
        private void FindObjectToChase()
        {
            ObjectToChase = FindClosest.Find<Friendly>(monster.transform);
        }
    }
}
