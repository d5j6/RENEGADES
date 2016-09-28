//C#
using System.Collections.Generic;

namespace RENEGADES.Constants
{

    public class AnimationTriggers
    {
        public enum PlayerAnimation
        {
            Down,
            Up,
            Left,
            Right
        }

        public enum EnemyAnimation
        {
            Walk,
            Attack
        }


        private static Dictionary<PlayerAnimation, string> PlayerAnimationLookup = new Dictionary<PlayerAnimation, string>()
        {
            {PlayerAnimation.Down,"Down"},
            {PlayerAnimation.Left,"Left"},
            {PlayerAnimation.Right,"Right"},
            {PlayerAnimation.Up,"Up" }
        };

        private static Dictionary<EnemyAnimation, string> EnemyAnimationLookup = new Dictionary<EnemyAnimation, string>()
        {
            {EnemyAnimation.Walk,"Walking"},
            {EnemyAnimation.Attack,"Swiping"},
        };



        public static string GetInput(PlayerAnimation input)
        {
            return PlayerAnimationLookup[input];
        }

        public static string GetInput(EnemyAnimation input)
        {
            return EnemyAnimationLookup[input];
        }
    }
}
