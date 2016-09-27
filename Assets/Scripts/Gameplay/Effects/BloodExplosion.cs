//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Effects
{
    public class BloodExplosion : Effect
    {
        //lifetime a bit longer here to stay on ground
        private const float LIFETIME = 7f;
        private float timer;
        private float fadeOutTimer = 5;

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
