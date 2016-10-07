//App
using RENEGADES.Constants;
using RENEGADES.Common.Gameplay;


namespace RENEGADES.Gameplay.AI
{
    public class EnemyAnimator : GenericAnimator
    {
        public AnimationTriggers.EnemyAnimation currentTrigger;

        public AnimationTriggers.EnemyAnimation SetAnimState(AnimationTriggers.EnemyAnimation trigger)
        {
            currentTrigger = trigger;
            SetTrigger(AnimationTriggers.GetInput(trigger));
            return currentTrigger;
        }


    }
}
