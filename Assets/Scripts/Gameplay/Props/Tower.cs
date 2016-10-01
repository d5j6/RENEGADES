//Game
using RENEGADES.Managers;

//Game
using RENEGADES.Gameplay.Basic;

namespace RENEGADES.Gameplay.Props
{
    public class Tower : Friendly
    {

        public override void SetHealth(float h)
        {
            base.SetHealth(400);
        }

        public override void Destroyed()
        {
            base.Destroyed();
            GameManager.Instance.EffectSpawner.Spawn(Controllers.Effects.EffectType.FireExplosion, transform.position);
            GameManager.Instance.AudioManager.PlaySound(Audio.Sounds.Sound.Explosion);
            Destroy(gameObject);

        }
    }
}
