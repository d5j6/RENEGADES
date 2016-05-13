//Unity
using UnityEngine;

//C#
using System.Collections.Generic;

namespace RENEGADES.Gameplay.Input
{
    public class ControllerManager : MonoBehaviour
    {
        public int count;

        private float CONNECTIONCHECK_REFRESHRATE = 0.35f;

        private void Awake()
        {
            InvokeRepeating("CHECK_CONTROLLERS", 0, CONNECTIONCHECK_REFRESHRATE);
        }

        private void CHECK_CONTROLLERS()
        {

        }

        public int GetPlayerCount()
        {
            return count;
        }

        private void OnDestroy()
        {
            CancelInvoke("CHECK_CONTROLLERS");
        }
        
    }
}
