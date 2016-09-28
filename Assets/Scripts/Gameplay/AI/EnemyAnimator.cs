//App
using RENEGADES.Constants;
using RENEGADES.Common.Gameplay;


namespace RENEGADES.Gameplay.AI
{
    public class EnemyAnimator : GenericAnimator
    {
        private AnimationTriggers.EnemyAnimation currentTrigger;

        public AnimationTriggers.EnemyAnimation SetAnimState(AnimationTriggers.EnemyAnimation trigger)
        {
            if (trigger == currentTrigger) return currentTrigger;
            currentTrigger = trigger;
            SetTrigger(AnimationTriggers.GetInput(trigger));
            return currentTrigger;
        }


    }
}
