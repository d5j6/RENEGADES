//App

//C#

//Unity
using UnityEngine.UI;

namespace RENEGADES.Common.UI
{
    public class GenericSlider : UIWidget
    {
        private Slider slider;
        private Slider _Slider
        {
            get { return slider ?? (slider = GetComponent<Slider>()); }
        }

        private Image sliderFill;
        private Image SliderFill
        {
            get { return sliderFill ?? (sliderFill = GetComponentsInChildren<Image>()[1]); }
        }

        private const float ANIM_SPEED = 0.25f;
        private const iTween.EaseType ANIM_EASE_TYPE = iTween.EaseType.easeInCubic;

        public void SetMaxValue(float m)
        {
            _Slider.maxValue = m;
        }

        public float GetMaxValue()
        {
            return _Slider.maxValue;
        }

        public void UpdateValue(float value)
        {
            ValueTo(value);
        }

        public void UpdateColor(UnityEngine.Color col)
        {
            ColorTo(col);
        }

        private void ValueTo(float value)
        {   //the gameobject that animates
            iTween.ValueTo(gameObject, iTween.Hash(
              "from", _Slider.value, 
              "to", value, 
              "time", ANIM_SPEED, 
              "easetype", ANIM_EASE_TYPE,
              "onupdate", "SliderValue_OnUpdate")); 
        }

        private void SliderValue_OnUpdate(float newValue) 
        {
            _Slider.value = newValue;
        }

        private void ColorTo(UnityEngine.Color col)
        {   //the gameobject that animates
            iTween.ValueTo(gameObject, iTween.Hash(
              "from", SliderFill.color,
              "to", col,
              "time", ANIM_SPEED,
              "easetype", ANIM_EASE_TYPE,
              "onupdate", "SliderColor_OnUpdate"));
        }

        private void SliderColor_OnUpdate(UnityEngine.Color newValue)
        {
           SliderFill.color = newValue;
        }

    }
}
