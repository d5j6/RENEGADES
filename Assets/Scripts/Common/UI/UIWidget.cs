//Unity
using UnityEngine;

namespace RENEGADES.Common.UI
{
    public class UIWidget : MonoBehaviour
    {
        private void Awake()
        {
            Init();
        }

        public virtual void Init() { }

    }
}
