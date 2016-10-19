//Game
using RENEGADES.Common.UI;

namespace RENEGADES.UI.Gameplay
{
    public class CrystalText : GenericText
    {

        public override void SetText(string s)
        {
            base.SetText(s);
            PunchAnimation(s);
        }

        private void PunchAnimation(string s)
        {
            int value = System.Convert.ToInt32(s);
            float bounceAmount = UnityEngine.Mathf.Clamp((value-1)*0.25f + 1.1f, 1.1f, 1.5f);
            iTween.PunchScale(gameObject, new UnityEngine.Vector3(bounceAmount, bounceAmount, bounceAmount), 1.0f);
        }
    }
}
