

namespace RENEGADES.Gameplay.Effects
{
    public class Build : Effect
    {
        private const float LIFETIME = 1.5f;

        public override void SetLifetime(float time)
        {
            base.SetLifetime(LIFETIME);
        }
    }
}
