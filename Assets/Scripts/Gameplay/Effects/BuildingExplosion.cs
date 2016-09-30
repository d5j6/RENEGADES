//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Effects
{
    public class BuildingExplosion : Effect
    {

        //explode
        private const float LIFETIME = 2f;
        private float timer;
        private float fadeOutTimer = 1;

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
