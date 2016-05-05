//App
using RENEGADES.Common;
using RENEGADES.UI.Effects;

//Unity
using UnityEngine;

namespace RENEGADES.UI.Connection
{
    public class ConnectionGlow : MonoBehaviour
    {
        private bool spin;

        private const float spinSpeed = 2;

        private Fade grid;
        private Fade Grid
        {
            get { return grid ?? (grid = GenComponent.ComponentCheck<Fade>(gameObject)); }
        }

        private void Awake()
        {
            Grid.SetInvisible();
        }

        public void Connected()
        {
            spin = true;
            Grid.FadeTo(1.0f, 1.0f);
        }

        public void Disconnected()
        {
            spin = false;
            Grid.FadeTo(0.0f, 0.0f);
        }
        private void Update()
        {
            if (spin) transform.eulerAngles += new Vector3(0, 0, spinSpeed);
        }
    }
}
