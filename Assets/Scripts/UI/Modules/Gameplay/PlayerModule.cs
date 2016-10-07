//Game
using RENEGADES.Common.UI;

namespace RENEGADES.UI.Gameplay
{

    public class PlayerModule : UIWidget
    {
        private HealthSlider healthSlider;
        private HealthSlider _HealthSlider
        {
            get { return healthSlider ?? (healthSlider = GetComponentInChildren<HealthSlider>()); }
        }

        public void SetMaxHealth(float h)
        {
            _HealthSlider.SetMaxValue(h);
        }

        public void UpdateHealth(float h)
        {
            _HealthSlider.UpdateHealth(h);
        }
    }
}
