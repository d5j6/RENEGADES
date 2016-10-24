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
            PlantBomb
        }

        private static Hashtable XboxInput = new Hashtable()
        {
            {PlayerInput.MovementX,"LeftJoystickHorizontal" },
            {PlayerInput.MovementY,"LeftJoystickVertical" },
            {PlayerInput.DirectionX,"RightJoyStickHorizontal" },
            {PlayerInput.DirectionY,"RightJoyStickVertical" },
            {PlayerInput.Attack,"RightTrigger" },
            {PlayerInput.PlantBomb,"LeftTrigger" }
        };

        public static string GetInput(PlayerInput input)
        {
            return (string)XboxInput[input];
        }

    }
}
