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
            return currentTrigger;
        }

        /// <summary>
        /// Set animation speed for idle
        /// </summary>
        /// <param name="speed"></param>
        public void SetAnimationSpeed(float speed)
        {
            PlayerAnim.speed = speed;
        }

        private void OnDestroy()
        {
            animator = null;
        }
    }
}
