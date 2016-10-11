//UNity
using RENEGADES.Managers;

namespace RENEGADES.Gameplay.AI.Turrets
{
    public class Lancer : Turret
    {
        public override void Init()
        {
            base.Init();
            BuildTurret(TurretType.TurretKey.Lancer);
        }

        public override void Fire()
        {
            base.Fire();
            GameManager.Instance.AudioManager.PlaySound(Audio.Sounds.Sound.LancerTankFire);
        }

    }
}
