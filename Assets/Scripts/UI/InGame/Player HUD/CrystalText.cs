//Game
using RENEGADES.Common.UI;

namespace RENEGADES.UI.Gameplay
{
    public class CrystalText : GenericText
    {

        private const float ANIM_TIME = 1.0f;
        private bool animating = false;

        private int previousValue;

        public override void SetText(string s)
        {
            base.SetText(s);
            PunchAnimation(s);
            previousValue = System.Convert.ToInt32(s);
        }

        private void PunchAnimation(string s)
        {
            int value = System.Convert.ToInt32(s);

            SetColor((value > previousValue) ? UnityEngine.Color.green : UnityEngine.Color.red);
            float bounceAmount = UnityEngine.Mathf.Clamp((value-1)*0.25f + 1.1f, 1.1f, 1.5f);
            if (!animating)
            {
                iTween.PunchScale(gameObject, new UnityEngine.Vector3(bounceAmount, bounceAmount, bounceAmount), 1.0f);
                Invoke("Anim_OnComplete", ANIM_TIME);
            }
            animating = true;
        }

        private void Anim_OnComplete()
        {
            SetColor(UnityEngine.Color.white);
            animating = false;
        }
    }
}
