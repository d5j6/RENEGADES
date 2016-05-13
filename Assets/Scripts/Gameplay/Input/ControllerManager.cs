//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.PlayerInput
{
    public class ControllerManager : MonoBehaviour
    {
        private int count = 0;

        private float CONNECTIONCHECK_REFRESHRATE = 0.35f;

        
        private void Awake()
        {
            InvokeRepeating("CHECK_CONTROLLERS", 0, CONNECTIONCHECK_REFRESHRATE);
        }

        private void CHECK_CONTROLLERS()
        {
            string[] joysticks =Input.GetJoystickNames();
            count = 0;
            foreach(string joystick in joysticks)
            {
                if (joystick.Length > 0) count++;
            }

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
