//UNity

//C#
using System.Collections;

//UNity

namespace RENEGADES.Constants
{
    //making calls to player input easier
    public static class GameInput
    {
        public enum PlayerInput
        {
            MovementX,
            MovementY,
            DirectionX,
            DirectionY,
            Attack,
            CharacterSpecial,
            Build,
            AButton,
            BButton
        }

        private static Hashtable XboxInput = new Hashtable()
        {
            {PlayerInput.MovementX,"LeftJoystickHorizontal" },
            {PlayerInput.MovementY,"LeftJoystickVertical" },
            {PlayerInput.DirectionX,"RightJoyStickHorizontal" },
            {PlayerInput.DirectionY,"RightJoyStickVertical" },
            {PlayerInput.Attack,"RightTrigger" }, //Space for keyboard
            {PlayerInput.CharacterSpecial,"LeftTrigger" }, // X for keyboard
            {PlayerInput.Build,"X Button" },//C on xbox controller
            {PlayerInput.AButton,"A Button" },
            {PlayerInput.BButton,"B Button" },

        };

        public static string GetInput(PlayerInput input)
        {
            return (string)XboxInput[input];
        }

    }
}
