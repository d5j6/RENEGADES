//App
using RENEGADES.UI.Gameplay;
using RENEGADES.Managers;
using RENEGADES.Common;
using RENEGADES.Gameplay.Basic;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.AI
{

    public class MonsterAI : Enemy
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

        private DeadState deadState;
        public DeadState _DeadState
        {
            get { return deadState; }
            set { deadState = value; }
        }

        private EnemyAnimator animator;
        public EnemyAnimator _EnemyAnimator
        {
            get { return animator ?? (animator = GenComponent.ComponentCheck<EnemyAnimator>(gameObject)); }
        }

        private HealthSlider enemyHealth;
        private HealthSlider EnemyHealthUI
        {
            get { return enemyHealth ?? (enemyHealth = GetComponentInChildren<HealthSlider>()); }
        }

        public Attributes _Attributes;

        /// <summary>
        /// Initialize
        /// </summary>
        public override void Init()
        {
            _Attributes = new Attributes();
            SetSpeed(0);
            SetAttackRange(0);
            SetAttackSpeed(0);
            SetDamage(0);
            EnemyHealthUI.SetHealth(HEALTH);

            attackingState = new AttackingState(this);
            walkingState = new WalkingState(this);
            deadState = new DeadState(this);
            currentState = walkingState;
            currentState.SetUp();
        }

        /// <summary>
        /// Called every frame
        /// </summary>
        public override void OnUpdate()
        {
            currentState.UpdateState();
        }

        /// <summary>
        /// set enemy position
        /// </summary>
        /// <param name="pos"></param>
        public void SetPosition(Vector3 pos)
        {
            transform.position = pos;
        }

        /// <summary>
        /// Set rotation of enemy
        /// </summary>
        public void SetRotation(Quaternion q)
        {
            transform.rotation = q;
        }

        /// <summary>
        /// Set speed in child
        /// </summary>
        /// <param name="s"></param>
        public virtual void SetSpeed(float s)
        {
            _Attributes.SPEED = s;
        }

        public virtual void SetAttackSpeed(float s)
        {
            _Attributes.ATTACK_SPEED = s;
        }

        public virtual void SetAttackRange(float r)
        {
            _Attributes.ATTACK_RANGE = r;
        }

        public virtual void SetDamage(float d)
        {
            _Attributes.DAMAGE = d;
        }

        /// <summary>
        /// Collision Detection
        /// </summary>
        /// <param name="other"></param>
        public override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            if (other.gameObject.tag == "RangedElement")
            {
                Hurt(other.transform.position);
            }
        }

        private void Hurt(Vector3 hitPosition)
        {
            //spawn blood splatter
            GameManager.Instance.EffectSpawner.CreateEffect(Controllers.Effects.EffectType.BloodSplat, hitPosition);
            UpdateHealth(-5);
            EnemyHealthUI.UpdateHealth(HEALTH);
        }

        /// <summary>
        /// Enemy is dead
        /// </summary>
        public virtual void RemoveFromBattleField()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _Attributes = null;
        }
    }
}
