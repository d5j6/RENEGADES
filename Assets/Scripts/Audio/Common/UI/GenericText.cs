//Unity
using TMPro;
using UnityEngine;

namespace RENEGADES.Common.UI
{
    public class GenericText : MonoBehaviour
    {

        private TextMeshProUGUI txt;
        private TextMeshProUGUI Txt
        {
            get { return txt ?? (txt = GetComponent<TextMeshProUGUI>()); }
        }

        public virtual void SetText(string s)
        {
            Txt.text = s;
        }

        public void SetColor(Color c)
        {
            Txt.color = c;
        }
    }
}
