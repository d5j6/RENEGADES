//C#
using System.Collections.Generic;

namespace RENEGADES.Constants
{

    public class AnimationTriggers
    {
        public enum AnimationTrigger
        {
            Down,
            Up,
            Left,
            Right
        }


        private static Dictionary<AnimationTrigger, string> InputLookUp = new Dictionary<AnimationTrigger, string>()
        {
            {AnimationTrigger.Down,"Down"},
            {AnimationTrigger.Left,"Left"},
            {AnimationTrigger.Right,"Right"},
            {AnimationTrigger.Up,"Up" }
        };

        public static string GetInput(AnimationTrigger input)
        {
            return InputLookUp[input];
        }
    }
}
