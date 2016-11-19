//UNity

//C#
using System.Collections;
using System.Collections.Generic;

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

        private static Hashtable XboxInput_Player1 = new Hashtable()
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

        private static Hashtable XboxInput_Player2 = new Hashtable()
        {
            {PlayerInput.MovementX,"LeftJoystickHorizontal_2" },
            {PlayerInput.MovementY,"LeftJoystickVertical_2" },
            {PlayerInput.DirectionX,"RightJoyStickHorizontal_2" },
            {PlayerInput.DirectionY,"RightJoyStickVertical_2" },
            {PlayerInput.Attack,"RightTrigger_2" }, 
            {PlayerInput.CharacterSpecial,"LeftTrigger_2" }, 
            {PlayerInput.Build,"X Button_2" },

        };

        private static Dictionary<int, Hashtable> PlayerInputLookup = new Dictionary<int, Hashtable>
        {
            {1,XboxInput_Player1 },
            {2,XboxInput_Player2 }
        };

        public static string GetInput(int player,PlayerInput input)
        {
            return (string)PlayerInputLookup[player][input];
        }

    }
}
