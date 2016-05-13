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

        private RawImage rawImage;
        private RawImage RImage
        {
            get { return rawImage ?? (rawImage = GetComponent<RawImage>()); }
        }

        public void ColorTo(Color color)
        {
            Color startColor = GetStartColor();
            iTween.ValueTo(gameObject, iTween.Hash(
              "from", startColor,
              "to", color,
              "time", CHANGE_TIME,
              "easetype", CHANGE_EASETYPE,
              "onupdate", "Color_OnUpdate"));
        }

        private void Color_OnUpdate(Color newValue)
        {
            if (Img != null) Img.color = newValue;
            if (RImage != null) RImage.color = newValue;
        }

        private Color GetStartColor()
        {
            if (Img != null) return Img.color;
            if (RImage != null) return RImage.color;
            Debug.LogError("No Necessary Color Change Component Found!");
            return Color.white;
        }

        private void OnDestroy()
        {
            img = null;
        }

    }
}
