//Unity
using UnityEngine;

namespace RENEGADES.Common.Gameplay
{
    public class GenericAnimator : MonoBehaviour
    {

        private Animator animator;
        private Animator Anim
        {
            get { return animator ?? (animator = GetComponent<Animator>()); }
        }

        /// <summary>
        /// Set animation speed for idle
        /// </summary>
        /// <param name="speed"></param>
        public void SetAnimationSpeed(float speed)
        {
            Anim.speed = speed;
        }

        public void SetTrigger(string s)
        {
            Anim.SetTrigger(s);
        }

        private void OnDestroy()
        {
            animator = null;
        }
    }
}
