//Game
using RENEGADES.Gameplay.Controllers;
using RENEGADES.Gameplay.Weapons;

//UNity
using UnityEngine;

namespace RENEGADES.Gameplay.AI
{
    //will control firing for the turrets
    public class Launcher : Spawner
    {

        public override void Init()
        {
            
        }

        public void FIRE(TurretType.TurretBlueprint blueprint)
        {
            Projectile spawn  = Spawn(blueprint.projectilePrefab) as Projectile;
            spawn.SetPosition(transform.position);
            spawn.SetEulerAngle(transform.eulerAngles.z);
            spawn.SetMoveSpeed(blueprint.projectileSpeed);
            spawn.SetMoveDirection(transform.up);
        }
    }
}
