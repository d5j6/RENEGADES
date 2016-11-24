//Unity
using UnityEngine;
using UnityEngine.UI;

namespace GameEngineering.Common.UI
{
    [RequireComponent(typeof(Button))]
    public class GenericButton : MonoBehaviour
    {

        private Button b;
        private Button ThisButon
        {
            get { return b ?? (b = GetComponent<Button>()); }
        }

        private RectTransform rect;
        public RectTransform Rect
        {
            get { return rect ?? (rect = GetComponent<RectTransform>()); }
        }

        private void Start()
        {
            ThisButon.onClick.AddListener(() => Button_OnSelected());
            Init();
        }

        private void Update()
        {
            OnUpdate();
        }

        public virtual void OnUpdate() { }

        public virtual void Init() { }

        public virtual void Button_OnSelected(){}

        public virtual void EnableInteraction(bool enable)
        {
            ThisButon.interactable = enable;
        }
    }
}
