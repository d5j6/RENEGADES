//App
using RENEGADES.Common.UI;

//Unity
using UnityEngine;

namespace RENEGADES.UI.Gameplay
{
    public class HealthSlider : GenericSlider
    {
        [Header("Colors for Health Amount")]
        public Color32 highHealth = new Color32(0, 255, 12, 255);
        public Color32 averageHealth = new Color32(255, 248, 0, 255);
        public Color32 lowHealth = new Color32(255, 0, 0, 255);

        public override void Init()
        {
            base.Init();
            UpdateColor(highHealth);
        }

        public void SetHealth(float m)
        {
            SetMaxValue(m);
        }

        public void UpdateHealth(float Health)
        {
            UpdateValue(Health);
            UpdateColor(DetermineColor(Health));
        }

        private Color32 DetermineColor(float health)
        {
            float percentage = health / GetMaxValue();
            if(percentage < 1 && percentage >= 0.75)
            {
                return highHealth;
            }
            else if(percentage < 0.75 && percentage >= 0.4f)
            {
                return averageHealth;
            }
            else
            {
                return lowHealth;
            }
        }

    }
}
