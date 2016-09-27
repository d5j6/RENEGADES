//Unity


namespace RENEGADES.Gameplay.Effects
{
    public class Bloodsplat : Effect
    {
        private const float LIFETIME = 1.5f;

        public override void SetLifetime(float time)
        {
            base.SetLifetime(LIFETIME);
        }
    }
}
