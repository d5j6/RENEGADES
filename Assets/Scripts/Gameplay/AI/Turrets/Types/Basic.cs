//UNity
using RENEGADES.Managers;

namespace RENEGADES.Gameplay.AI.Turrets
{
    public class Basic : Turret
    {
        public override void Init()
        {
            base.Init();
            BuildTurret(TurretType.TurretKey.Basic);
        }

        public override void Fire()
        {
            base.Fire();
            GameManager.Instance.AudioManager.PlaySound(Audio.Sounds.Sound.BasicTankFire);
        }

    }
}