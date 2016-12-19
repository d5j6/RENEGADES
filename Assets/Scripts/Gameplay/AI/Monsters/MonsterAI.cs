//App
using RENEGADES.UI.Gameplay;
using RENEGADES.Managers;
using RENEGADES.Common;
using RENEGADES.Gameplay.Basic;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.AI.Monsters
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

        #region MONSTER vars
        public MonsterBlueprint.EnemyBlueprint blueprint;
        #endregion

        /// <summary>
        /// Initialize
        /// </summary>
        public override void Init()
        {
            attackingState = new AttackingState(this);
            walkingState = new WalkingState(this);
            deadState = new DeadState(this);
            currentState = walkingState;
            currentState.SetUp();
        }

        public void BuildMonster(MonsterBlueprint.EnemyBlueprint blueprint)
        {
            this.blueprint = blueprint;
            SetHealth(blueprint.health);
            EnemyHealthUI.SetHealth(HEALTH);
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
                GameManager.Instance.EffectSpawner.CreateEffect(EffectBlueprint.EffectType.BloodSplat, p.transform.position);
                ChangeHealth(-p.GetDamage());
            }
        }

        public override void ChangeHealth(float h)
        {
            base.ChangeHealth(h);
            EnemyHealthUI.UpdateHealth(HEALTH);
        }

        /// <summary>
        /// Enemy is dead
        /// </summary>
        public virtual void RemoveFromBattleField()
        {
            GameManager.Instance.ItemSpawner.SpawnCluster(blueprint.difficulty, GetPosition()); //SPAWN CLUSTER OF ITEMS
            GameManager.Instance.AudioManager.PlaySound(blueprint.deathSound);
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            attackingState = null;
            deadState = null;
            walkingState = null;
            currentState = null;
        }
    }
}
