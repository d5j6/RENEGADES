﻿//App
using RENEGADES.Constants;
using RENEGADES.Common.Gameplay;


namespace RENEGADES.Gameplay.Players
{
    public class PlayerAnimator : GenericAnimator
    {
        private AnimationTriggers.PlayerAnimation currentTrigger;

        public AnimationTriggers.PlayerAnimation SetAnimState(AnimationTriggers.PlayerAnimation trigger)
        {
            if (trigger == currentTrigger) return currentTrigger;
            currentTrigger = trigger;
            SetTrigger(AnimationTriggers.GetInput(trigger));
            return currentTrigger;
        }

        
    }
}
