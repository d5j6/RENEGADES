//App
using RENEGADES.Common.Gameplay;
using RENEGADES.Gameplay.Basic;
using RENEGADES.Managers;
using RENEGADES.UI.Gameplay;
using RENEGADES.Common;

//UNity
using UnityEngine;

namespace RENEGADES.Gameplay.AI
{

    public class Turret : Friendly
    {
        public TurretType type;

        private TurretType.TurretBlueprint Blueprint;

        private Enemy enemyToLookAt;

        private HealthSlider healthUI;
        private HealthSlider HealthUI
        {
            get { return healthUI ?? (healthUI = GetComponentInChildren<HealthSlider>()); }
        }

        private Launcher launcher;
        private Launcher _Launcher
        {
            get { return launcher ?? (launcher = GenComponent.ComponentCheck<Launcher>(gameObject)); }
        }

        private float reDirectTimer;
        private float DIRECT_TIME = 1.0f;

        private float turnAngle;

        private float cooldownTimer = 0;

        public override void Init()
        {
            base.Init();
            BuildTurret(TurretType.TurretKey.Basic);
        }

        public void BuildTurret(TurretType.TurretKey key)
        {
            Blueprint = type.TurretTypes.Find(x => x.key == key);
            SetHealth(Blueprint.health);
            HealthUI.SetMaxValue(Blueprint.health);
            SetSprite(Blueprint.sprite);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            Search();
            TurnTowards();
            TargetInSight();
        }

        private void TurnTowards()
        {
            if (enemyToLookAt == null) return;
            float theta = Mathf.Atan2(enemyToLookAt.GetPosition().x - GetPosition().x, enemyToLookAt.GetPosition().y - GetPosition().y);
            theta = (theta > 0 ? theta : (2 * Mathf.PI + theta)) * Mathf.Rad2Deg - 360;
            turnAngle = Mathf.Abs(theta);
            float currentAngle = Mathf.Lerp(transform.eulerAngles.z, turnAngle, Blueprint.turnSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0, currentAngle);
        }

        private void TargetInSight()
        {
            if (cooldownTimer > 0)
            {
                cooldownTimer -= Time.deltaTime;
            }
            if (enemyToLookAt == null) return;
            RaycastHit2D InLineOfCannon = Physics2D.Raycast(GetPosition(), transform.up, Mathf.Infinity, enemyToLookAt.GetLayer());
            if (InLineOfCannon == true & CannonRecharged()) Fire();
        }

        private void Fire()
        {
            cooldownTimer = Blueprint.fireRate; //recharge
            _Launcher.FIRE(Blueprint);
        }

        public override void Hurt(float h)
        {
            base.Hurt(h);
            HealthUI.UpdateHealth(HEALTH);
        }

        private void Search()
        {
            reDirectTimer += Time.deltaTime;
            if (reDirectTimer > DIRECT_TIME)
            {
                FindEnemy();
                reDirectTimer = 0;
            }
        }

        public void FindEnemy()
        {
            enemyToLookAt = FindClosest.Find<Enemy>(transform, Blueprint.range);
        }

        private bool CannonRecharged()
        {
            return cooldownTimer <= 0;
        }

        public override void Destroyed()
        {
            base.Destroyed();
            GameManager.Instance.EffectSpawner.CreateEffect(Controllers.Effects.EffectType.FireExplosion, transform.position);
            GameManager.Instance.AudioManager.PlaySound(Audio.Sounds.Sound.Explosion);
            Destroy(gameObject);

        }

    }
}
