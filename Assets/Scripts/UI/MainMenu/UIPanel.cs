//Unity
using UnityEngine;

//Game
using RENEGADES.Common.UI;

namespace RENEGADES.UI.MainMenu
{
    [RequireComponent(typeof(SetFirstSelected))]
    public class UIPanel : UIWidget
    {
        private bool visible;
        private const float FADE_SPEED = 5f;

        public override void Init()
        {
            base.Init();
            SetAlpha(0);
            SetVisible(true);
            EnableInteraction(true);
        }

        public void SetVisible(bool v)
        {
            visible = v;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            SetAlpha(iTween.FloatUpdate(GetAlpha(), visible ? 1 : 0,FADE_SPEED));
        }

        public void Disable()
        {
            SetVisible(false);
            EnableInteraction(false);
        }
    }
}
