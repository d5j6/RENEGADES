//Game
using RENEGADES.Managers;
using RENEGADES.Gameplay.Basic;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Props
{
    /// <summary>
    /// Our Tower that we are defending
    /// </summary>
    public class Tower : Friendly
    {
        private float colorCalc;

        public override void OnUpdate()
        {
            base.OnUpdate();
            colorCalc = HEALTH / (GetMaxHealth());
            SetColor(Color.Lerp(Color.red, Color.white, colorCalc));
        }

        public override void SetHealth(float h)
        {
            base.SetHealth(400);
        }

        public override void Destroyed()
        {
            base.Destroyed();
            GameManager.Instance.EffectSpawner.CreateEffect(EffectBlueprint.EffectType.FireExplosion, transform.position);
            GameManager.Instance.AudioManager.PlaySound(Audio.Sounds.Sound.Explosion);
            Destroy(gameObject);

        }
    }
}
