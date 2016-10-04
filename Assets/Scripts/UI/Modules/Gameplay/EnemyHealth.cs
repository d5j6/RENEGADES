//App
using RENEGADES.Common.UI;

//Unity
using UnityEngine;

namespace RENEGADES.UI.Gameplay
{
    public class EnemyHealth : GenericSlider
    {
        private Color32 green = new Color32(0, 255, 12, 255);
        private Color32 red = new Color32(255, 0, 0, 255);
        private Color32 yellow = new Color32(255, 248, 0, 255);

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
                return green;
            }
            else if(percentage < 0.75 && percentage >= 0.4f)
            {
                return yellow;
            }
            else
            {
                return red;
            }
        }

    }
}
