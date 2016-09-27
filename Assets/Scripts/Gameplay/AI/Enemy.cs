//App
using RENEGADES.UI.Gameplay;
using RENEGADES.Managers;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.AI
{
    [RequireComponent(typeof(Rigidbody2D))]
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

        private Rigidbody2D rigid;
        public Rigidbody2D EnemyRigidBody
        {
            get { return rigid ?? (rigid = GetComponent<Rigidbody2D>()); }
        }

        private EnemyHealth enemyHealth;
        private EnemyHealth EnemyHealthUI
        {
            get { return enemyHealth ?? (enemyHealth = GetComponentInChildren<EnemyHealth>()); }
        }

        public float HEALTH;
        public float SPEED;

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
            SetHealth(0);
            SetSpeed(0);
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
            HEALTH = h;
            EnemyHealthUI.SetHealth(HEALTH);
        }

        /// <summary>
        /// Set speed in child
        /// </summary>
        /// <param name="s"></param>
        public virtual void SetSpeed(float s)
        {
            SPEED = s;
        }

        /// <summary>
        /// Update our health
        /// </summary>
        /// <param name="value"></param>
        public void UpdateHealth(float value)
        {
            HEALTH += value;
            EnemyHealthUI.UpdateHealth(HEALTH);
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
    }
}
