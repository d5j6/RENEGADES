//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.PlayerInput
{
    public class ControllerManager : MonoBehaviour
    {
        private int count = 0;
        private void Awake()
        {

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

        public int GetControllerCount()
        {
            CHECK_CONTROLLERS();
            return count;
        }

        public bool AnyControllersConnected()
        {
            CHECK_CONTROLLERS();
            return (count > 0) ? true : false;
        }

        private void OnDestroy()
        {
            
        }
        
    }
}
