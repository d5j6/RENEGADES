//App
using RENEGADES.Constants;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Players
{
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator animator;
        private Animator PlayerAnim
        {
            get { return animator ?? (animator = GetComponent<Animator>()); }
        }

        private AnimationTriggers.AnimationTrigger currentTrigger;

        public AnimationTriggers.AnimationTrigger SetAnimState(AnimationTriggers.AnimationTrigger trigger)
        {
            if (trigger == currentTrigger) return currentTrigger;
            currentTrigger = trigger;
            PlayerAnim.SetTrigger(AnimationTriggers.GetInput(trigger));
            PlayerAnim.speed = 1.0f;
            return currentTrigger;
        }

        public AnimationTriggers.AnimationTrigger SetAnimState()
        {
            PlayerAnim.speed = 0.0f;
            return currentTrigger;
        }

        private void OnDestroy()
        {
            animator = null;
        }
    }
}
