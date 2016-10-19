//Game
using RENEGADES.Managers;

namespace RENEGADES.Gameplay.Items
{
    public class HealthPotion : Item
    {
        private const float HEALTH_INCREASE = 10;
        public override void PickUP()
        {
            base.PickUP();
            GameManager.Instance.AudioManager.PlaySound(Audio.Sounds.Sound.Burp);
            GetPlayer().ChangeHealth(HEALTH_INCREASE);
        }

    }
}
