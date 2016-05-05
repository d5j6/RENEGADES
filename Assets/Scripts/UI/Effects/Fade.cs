//Unity
using UnityEngine;

namespace RENEGADES.UI.Effects
{
    //Custom Class to add to objects that you want to fade in and out
    [RequireComponent(typeof(CanvasGroup))]
    public class Fade: MonoBehaviour
    {

        private CanvasGroup grid;
        public CanvasGroup Grid
        {
            get { return grid; }
        }

        //Called on Application Start
        private void Awake()
        {
            grid = GetComponent<CanvasGroup>();
        }

        public void FadeTo(float alpha, float speed)
        {
            iTween.ValueTo(gameObject, iTween.Hash(
              "from", grid.alpha,
              "to", alpha,
              "time", speed,
              "onupdate", "Alpha"));
        }

        private void Alpha(float newValue)
        {
            grid.alpha = newValue;
        }

        public void SetInvisible()
        {
            Grid.alpha = 0.0f;
        }

        public void EnableInteraction(bool enable)
        {
            grid.blocksRaycasts = enable;
            grid.interactable = enable;
        }

    }
}
