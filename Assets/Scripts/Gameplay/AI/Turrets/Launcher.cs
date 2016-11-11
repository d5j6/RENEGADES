//Game
using RENEGADES.Gameplay.Weapons;
using GameEngineering.Common;


//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.AI.Turrets
{
    //will control firing for the turrets
    public class Launcher : GenericPooler
    {

        public override void Init()
        {
            base.Init();
            SetIdealTransform(GameObject.Find("Pooled Object Container").transform);
        }

        public void FIRE(TurretType.TurretBlueprint blueprint)
        {
            Projectile spawn = GetPooledObject(transform.position) as Projectile;
            spawn.SetEulerAngle(transform.eulerAngles.z);
            spawn.SetMoveSpeed(blueprint.projectileSpeed);
            spawn.SetMoveDirection(transform.up);
            spawn.SetDamage(blueprint.projectileDamage);
        }
    }
}
