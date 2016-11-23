//Unity
using UnityEngine;

//Game


namespace RENEGADES.Common.UI
{
    public class UIWidget : MonoBehaviour
    {

        private void Awake()
        {
            Init();
        }

        public virtual void Init() { }

        private void Update()
        {
            OnUpdate();
        }

        public virtual void OnUpdate() { }

        private CanvasGroup grid;
        private CanvasGroup Grid
        {
            get { return grid ?? (grid = GenComponent.ComponentCheck<CanvasGroup>(gameObject)); }
        }

        private RectTransform rect;
        public RectTransform Rect
        {
            get { return rect ?? (rect = GetComponent<RectTransform>()); }
        }

        public void EnableInteraction(bool enable)
        {
            Grid.blocksRaycasts = Grid.interactable = enable;
        }

        public void SetAlpha(float alpha)
        {
            Grid.alpha = alpha;
        }

        public float GetAlpha()
        {
            return Grid.alpha;
        }

    }
}
