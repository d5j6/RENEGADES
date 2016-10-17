//App
using RENEGADES.UI.Gameplay;
using RENEGADES.Managers;
using RENEGADES.Common;
using RENEGADES.Gameplay.Basic;
using RENEGADES.Gameplay.Effects;

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
            SetDifficulty(DIFFICULTY.Easy);
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

        public virtual void SetDifficulty(DIFFICULTY d)
        {
            _Attributes.difficulty = d;
        }

        /// <summary>
        /// Collision Detection
        /// if a monster is hit by a projectile
        /// </summary>
        /// <param name="other"></param>
        public override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            Weapons.Projectile p = other.GetComponent<Weapons.Projectile>();
            if (p != null)
            {
                GameManager.Instance.EffectSpawner.CreateEffect(EffectGenerator.EffectType.BloodSplat,p.transform.position);
                Hurt(-p.GetDamage());
                EnemyHealthUI.UpdateHealth(HEALTH);
            }
        }

        /// <summary>
        /// Enemy is dead
        /// </summary>
        public virtual void RemoveFromBattleField()
        {
            GameManager.Instance.ItemSpawner.SpawnCluster(_Attributes.difficulty, GetPosition());
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _Attributes = null;
        }
    }
}
