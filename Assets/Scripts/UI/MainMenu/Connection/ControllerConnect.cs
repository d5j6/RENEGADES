﻿//App
using RENEGADES.UI.Effects;

//Unity
using UnityEngine;

namespace RENEGADES.UI.Connection
{
    public class ControllerConnect : MonoBehaviour
    {

        private ColorChange colChange;
        private ColorChange ColChange
        {
            get { return colChange ?? (colChange = GetComponent<ColorChange>()); }
        }

        private ConnectionGlow glow;
        private ConnectionGlow Glow
        {
            get { return glow ?? (glow = GetComponentInChildren<ConnectionGlow>()); }
        }

        private Color32 activeColor = new Color32(0, 255, 107, 255);

        private void Awake()
        {
           
        }

        public void CONNECTED()
        {
            ColChange.ColorTo(activeColor);
            Glow.Connected();
        }

        public void DISCONNECTED()
        {
            ColChange.ColorTo(Color.red);
            Glow.Disconnected();
        }

        private void OnDestroy()
        {
            colChange = null;
            glow = null;
        }
    }
}
