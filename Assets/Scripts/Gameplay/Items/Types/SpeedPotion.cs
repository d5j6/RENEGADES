//Game
using RENEGADES.Gameplay.Players.Upgrades;
using RENEGADES.Managers;

namespace RENEGADES.Gameplay.Items
{
    public class SpeedPotion : Item
    {
        public override void PickUP()
        {
            base.PickUP();
            GameManager.Instance.AudioManager.PlaySound(Audio.Sounds.Sound.Woosh);
            AddSpeed();
        }

        private void AddSpeed()
        {
            SpeedBoost boost = GetPlayer().GetComponent<SpeedBoost>();
            if (boost == null) GetPlayer().gameObject.AddComponent<SpeedBoost>();
            else { boost.AddJuice(); }
        }
    }
}
