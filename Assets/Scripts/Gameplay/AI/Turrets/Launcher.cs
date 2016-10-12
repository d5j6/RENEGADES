//Game
using RENEGADES.Gameplay.Controllers;
using RENEGADES.Gameplay.Weapons;
using RENEGADES.Common;
using RENEGADES.Common.Gameplay;

namespace RENEGADES.Gameplay.AI.Turrets
{
    //will control firing for the turrets
    public class Launcher : Spawner
    {
        private GenericPooler pooler;
        private GenericPooler Pooler
        {
            get { return pooler ?? (pooler = GenComponent.ComponentCheck<GenericPooler>(gameObject)); }
        }

        public override void Init()
        {
            
        }

        public void FIRE(TurretType.TurretBlueprint blueprint)
        {
            Projectile spawn = Pooler.GetPooledObject(blueprint.projectilePrefab) as Projectile;
            spawn.SetPosition(transform.position);
            spawn.SetEulerAngle(transform.eulerAngles.z);
            spawn.SetMoveSpeed(blueprint.projectileSpeed);
            spawn.SetMoveDirection(transform.up);
            spawn.SetDamage(blueprint.projectileDamage);
        }
    }
}
