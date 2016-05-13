//C#
using System.Collections.Generic;

namespace RENEGADES.Constants
{
    //making calls to player input easier
    public static class GameInput
    {
        public enum PlayerInput
        {
            LeftJoyHorizontal,
            LeftJoyVertical,
            RightJoyHoriztonal,
            RightJoyVertical
        }

        private static Dictionary<PlayerInput, string> InputLookUp = new Dictionary<PlayerInput, string>()
        {
            {PlayerInput.LeftJoyHorizontal,"LeftJoystickHorizontal" },
            {PlayerInput.LeftJoyVertical,"LeftJoystickVertical" },
            {PlayerInput.RightJoyHoriztonal,"RightJoyStickHorizontal" },
            {PlayerInput.RightJoyVertical,"RightJoyStickVertical" }
        };

        public static string GetInput(PlayerInput input)
        {
            return InputLookUp[input];
        }

    }
}
