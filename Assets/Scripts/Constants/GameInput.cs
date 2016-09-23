//UNity
using RENEGADES.Managers;

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
            Attack
        }

        private static Hashtable XboxInput = new Hashtable()
        {
            {PlayerInput.MovementX,"LeftJoystickHorizontal" },
            {PlayerInput.MovementY,"LeftJoystickVertical" },
            {PlayerInput.DirectionX,"RightJoyStickHorizontal" },
            {PlayerInput.DirectionY,"RightJoyStickVertical" },
            {PlayerInput.Attack,"RightTrigger" }
        };

        private static Hashtable PCInput = new Hashtable()
        {
            {PlayerInput.MovementX,"Left arrow" },
            {PlayerInput.MovementY,"Right arrow" },
            {PlayerInput.DirectionX,"Horizontal"},
            {PlayerInput.DirectionY,"Vertical" },
            {PlayerInput.Attack,"Space Bar" }
        };

        public static string GetInput(PlayerInput input)
        {
            if (GameManager.Instance.ControllerManager.AnyControllersConnected()) return (string)XboxInput[input];
            return (string)PCInput[input];
        }

    }
}
