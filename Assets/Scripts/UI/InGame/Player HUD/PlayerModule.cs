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

        private CrystalText crystalText;
        private CrystalText _CrystalText
        {
            get { return crystalText ?? (crystalText = GetComponentInChildren<CrystalText>()); }
        }

        public void SetMaxHealth(float h)
        {
            _HealthSlider.SetMaxValue(h);
        }

        public void UpdateHealth(float h)
        {
            _HealthSlider.UpdateHealth(h);
        }

        public void UpdateCrystal(float c)
        {
            _CrystalText.SetText(c.ToString());
        }
    }
}
