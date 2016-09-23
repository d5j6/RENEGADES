//App
using RENEGADES.Gameplay.Weapons;
using RENEGADES.Constants;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Players
{
    public class Player : MonoBehaviour
    {
        private PlayerAnimator animator;
        private PlayerAnimator PlayerAnim
        {
            get { return animator ?? (animator = GetComponent<PlayerAnimator>()); }
        }

        private PlayerMovement playerMovement;
        private PlayerMovement PlayerMove
        {
            get { return playerMovement ?? (playerMovement = GetComponent<PlayerMovement>()); }
        }

        private RangedAttack rangedAttack;
        private RangedAttack RangedAttack
        {
            get { return rangedAttack ?? (rangedAttack = GetComponentInChildren<RangedAttack>()); }
        }

        private AnimationTriggers.AnimationTrigger currentTrigger;
        public AnimationTriggers.AnimationTrigger CurrentTrigger
        {
            get { return currentTrigger; }
        }

        private void Awake()
        {
        }

        //player main game loop
        private void FixedUpdate()
        {
            AnimationLoop();
            RangedAttackLoop();
        }

        private void AnimationLoop()
        {
            PlayerMovement.LookParams looksParams = PlayerMove.Move();
            if (Mathf.Abs(looksParams.rightJoyStickX) > Mathf.Abs(looksParams.rightJoyStickY))
            {
                currentTrigger = PlayerAnim.SetAnimState(looksParams.rightJoyStickX > 0 ? AnimationTriggers.AnimationTrigger.Right : AnimationTriggers.AnimationTrigger.Left);
            }
            else if (Mathf.Abs(looksParams.rightJoyStickX) < Mathf.Abs(looksParams.rightJoyStickY))
            {
                
                currentTrigger = PlayerAnim.SetAnimState(looksParams.rightJoyStickY > 0 ? AnimationTriggers.AnimationTrigger.Up : AnimationTriggers.AnimationTrigger.Down);
            }
            else
            {
                
                currentTrigger = PlayerAnim.SetAnimState(); // idle
            }
        }

        private void RangedAttackLoop()
        {
            if (Input.GetAxis(GameInput.GetInput(GameInput.PlayerInput.Attack)) > 0)
            {
                RangedAttack.FIRE(this);
            }
        }
    }
}
