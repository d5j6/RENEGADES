//App
using RENEGADES.UI.Gameplay;
using RENEGADES.Managers;
using RENEGADES.Common;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.AI
{

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

        private EnemyHealth enemyHealth;
        private EnemyHealth EnemyHealthUI
        {
            get { return enemyHealth ?? (enemyHealth = GetComponentInChildren<EnemyHealth>()); }
        }

        public Attributes Attributes;

        /// <summary>
        /// Called on start
        /// </summary>
        private void Awake()
        {
            Init();
            attackingState = new AttackingState(this);
            walkingState = new WalkingState(this);
            deadState = new DeadState(this);
            currentState = walkingState;
        }

        /// <summary>
        /// Initialize
        /// </summary>
        private void Init()
        {
            Attributes = new Attributes();
            SetHealth(0);
            SetSpeed(0);
            SetAttackRange(0);
            SetAttackSpeed(0);
        }

        /// <summary>
        /// Called every frame
        /// </summary>
        private void Update()
        {
            currentState.UpdateState();
        }

        /// <summary>
        /// Get enemy position
        /// </summary>
        /// <returns></returns>
        public Vector3 GetPosition()
        {
            return transform.position;
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
        /// Init Set health
        /// </summary>
        /// <param name="h"></param>
        public virtual void SetHealth(float h)
        {
            Attributes.HEALTH = h;
            EnemyHealthUI.SetHealth(Attributes.HEALTH);
        }

        /// <summary>
        /// Set speed in child
        /// </summary>
        /// <param name="s"></param>
        public virtual void SetSpeed(float s)
        {
            Attributes.SPEED = s;
        }

        public virtual void SetAttackSpeed(float s)
        {
            Attributes.ATTACK_SPEED = s;
        }

        public virtual void SetAttackRange(float r)
        {
            Attributes.ATTACK_RANGE = r;
        }

        /// <summary>
        /// Update our health
        /// </summary>
        /// <param name="value"></param>
        public void UpdateHealth(float value)
        {
            Attributes.HEALTH += value;
            EnemyHealthUI.UpdateHealth(Attributes.HEALTH);
        }

        /// <summary>
        /// Collision Detection
        /// </summary>
        /// <param name="other"></param>
        public virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "RangedElement")
            {
                //spawn blood splatter
                GameManager.Instance.EffectSpawner.Spawn(Controllers.Effects.EffectType.BloodSplat, other.transform.position);
                UpdateHealth(-5);
            }
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
            Attributes = null;
        }
    }
}
