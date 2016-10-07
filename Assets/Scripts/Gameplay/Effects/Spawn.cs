
namespace RENEGADES.Gameplay.Effects
{
    public class Spawn : Effect
    {

        private const float LIFETIME = 0.75f;

        public override void SetLifetime(float time)
        {
            base.SetLifetime(LIFETIME);
        }
    }
}
