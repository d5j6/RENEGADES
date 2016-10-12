//Game
using RENEGADES.Gameplay.Weapons;
using RENEGADES.Common.Gameplay;

namespace RENEGADES.Gameplay.AI.Turrets
{
    //will control firing for the turrets
    public class Launcher : GenericPooler
    {

        public void FIRE(TurretType.TurretBlueprint blueprint)
        {
            Projectile spawn = GetPooledObject(blueprint.projectilePrefab) as Projectile;
            spawn.SetPosition(transform.position);
            spawn.SetEulerAngle(transform.eulerAngles.z);
            spawn.SetMoveSpeed(blueprint.projectileSpeed);
            spawn.SetMoveDirection(transform.up);
            spawn.SetDamage(blueprint.projectileDamage);
        }
    }
}
