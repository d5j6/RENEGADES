//Game
using RENEGADES.Gameplay.Weapons;
using RENEGADES.Gameplay.Controllers;

namespace RENEGADES.Gameplay.AI.Turrets
{
    //will control firing for the turrets
    public class Launcher : Spawner
    {

        public override void Init()
        {
            
        }

        public void FIRE(TurretType.TurretBlueprint blueprint)
        {
            Projectile spawn = Spawn(blueprint.projectilePrefab);
            spawn.SetPosition(transform.position);
            spawn.SetEulerAngle(transform.eulerAngles.z);
            spawn.SetMoveSpeed(blueprint.projectileSpeed);
            spawn.SetMoveDirection(transform.up);
            spawn.SetDamage(blueprint.projectileDamage);
        }
    }
}
