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

        private Rigidbody2D rigid;
        private Rigidbody2D EnemyRigidBody
        {
            get { return rigid ?? (rigid = GetComponent<Rigidbody2D>()); }
        }

        private EnemyHealth enemyHealth;
        private EnemyHealth EnemyHealthUI
        {
            get { return enemyHealth ?? (enemyHealth = GetComponentInChildren<EnemyHealth>()); }
        }

        public float HEALTH;

        /// <summary>
        /// Called on start
        /// </summary>
        private void Awake()
        {
            attackingState = new AttackingState(this);
            walkingState = new WalkingState(this);
            currentState = walkingState;
            Init();
        }

        /// <summary>
        /// Initialize
        /// </summary>
        private void Init()
        {
            SetHealth(0);
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
        /// Move enemy by rigidbody
        /// </summary>
        /// <param name="SPEED"></param>
        public virtual void MOVE(float SPEED)
        {
            EnemyRigidBody.AddForce(-transform.up * SPEED);
            EnemyRigidBody.velocity = Vector3.ClampMagnitude(EnemyRigidBody.velocity, SPEED);
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
    }
}
