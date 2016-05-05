//Unity
using UnityEngine;
using UnityEngine.UI;

namespace RENEGADES.UI.Effects
{
    public class ColorChange : MonoBehaviour
    {

        private const float CHANGE_TIME = 1.0f;
        private const iTween.EaseType CHANGE_EASETYPE = iTween.EaseType.easeInOutCubic;

        private Image img;
        private Image Img
        {
            get { return img ?? (img = GetComponent<Image>()); }
        }

        public void ColorTo(Color color)
        {
            iTween.ValueTo(gameObject, iTween.Hash(
              "from", Img.color,
              "to", color,
              "time", CHANGE_TIME,
              "easetype", CHANGE_EASETYPE,
              "onupdate", "Color_OnUpdate"));
        }

        private void Color_OnUpdate(Color newValue)
        {
            Img.color = newValue;
        }

    }
}
