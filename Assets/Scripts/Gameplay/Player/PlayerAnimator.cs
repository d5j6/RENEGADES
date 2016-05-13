//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator animator;
        private Animator PlayerAnim
        {
            get { return animator ?? (animator = GetComponent<Animator>()); }
        }

        private void OnDestroy()
        {
            animator = null;
        }
    }
}
