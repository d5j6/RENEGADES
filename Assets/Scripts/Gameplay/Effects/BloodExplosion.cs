//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Effects
{
    public class BloodExplosion : Effect
    {
        //lifetime a bit longer here to stay on ground
        private const float LIFETIME = 15f;
        private float timer;
        private float fadeOutTimer =12;

        public override void SetLifetime(float time)
        {
            base.SetLifetime(LIFETIME);
        }

        //called every frame
        public override void OnUpdate()
        {
            base.OnUpdate();
            timer += Time.deltaTime;
            if (timer > fadeOutTimer) fadeOut = true;
        }

    }
}
