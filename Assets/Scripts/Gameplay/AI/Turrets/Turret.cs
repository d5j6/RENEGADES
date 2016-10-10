//App
using RENEGADES.Common.Gameplay;
using RENEGADES.Gameplay.Basic;
using RENEGADES.Gameplay.Players;

//UNity
using UnityEngine;

namespace RENEGADES.Gameplay.AI
{

    public class Turret : Friendly
    {
        public TurretType type;

        private TurretType.TurretBlueprint Blueprint;

        private Player enemyToLookAt;

        private float reDirectTimer;
        private float DIRECT_TIME = 1.0f;

        private float turnAngle;

        public override void Init()
        {
            base.Init();
            BuildTurret(TurretType.TurretKey.Basic);
        }

        public void BuildTurret(TurretType.TurretKey key)
        {
            Blueprint = type.TurretTypes.Find(x => x.key == key);
            SetHealth(Blueprint.health);
            SetSprite(Blueprint.sprite);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            Search();
            TurnTowards();
        }

        private void TurnTowards()
        {
            if (enemyToLookAt == null) return;
            Vector3 targetDir = enemyToLookAt.GetPosition() - GetPosition();
            if (targetDir.x > 0)
            {

            }
            else
            {
                turnAngle = 
            }

            float currentAngle = Mathf.Lerp(transform.eulerAngles.z, turnAngle, 5 * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0, currentAngle);
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
            enemyToLookAt = FindClosest.Find<Player>(transform, Blueprint.range);
        }

    }
}
