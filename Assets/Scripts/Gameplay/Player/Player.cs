//App
using RENEGADES.UI.Gameplay;
using RENEGADES.Gameplay.Basic;
using RENEGADES.Gameplay.Weapons;
using RENEGADES.Constants;
using RENEGADES.Managers;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Players
{
    public class Player : Friendly
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

        private AnimationTriggers.PlayerAnimation currentTrigger;
        public AnimationTriggers.PlayerAnimation CurrentTrigger
        {
            get { return currentTrigger; }
        }

        private PlayerModule playerHUD;
        private PlayerModule PlayerHUD
        {
            get { return playerHUD; } set { playerHUD = value; }
        }

        public override void SetHealth(float h)
        {
            base.SetHealth(100);
            //healthUI.SetMaxValue(100);
        }

        public override void Hurt(float health)
        {
            base.Hurt(health);
           // healthUI.UpdateHealth(HEALTH);
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

            float animSpeed = (Mathf.Abs(looksParams.LeftJoyStickX) > 0 || Mathf.Abs(looksParams.LeftJoyStickY) > 0) ? 1.0f : 0.0f;
            PlayerAnim.SetAnimationSpeed(animSpeed);

            if (Mathf.Abs(looksParams.rightJoyStickX) > Mathf.Abs(looksParams.rightJoyStickY))
            {
                currentTrigger = PlayerAnim.SetAnimState(looksParams.rightJoyStickX > 0 ? AnimationTriggers.PlayerAnimation.Right : AnimationTriggers.PlayerAnimation.Left);
            }
            else if (Mathf.Abs(looksParams.rightJoyStickX) < Mathf.Abs(looksParams.rightJoyStickY))
            {

                currentTrigger = PlayerAnim.SetAnimState(looksParams.rightJoyStickY > 0 ? AnimationTriggers.PlayerAnimation.Up : AnimationTriggers.PlayerAnimation.Down);
            }

        }

        private void RangedAttackLoop()
        {
            if (GameManager.Instance._ControllerManager.AnyControllersConnected())
            {
                if (Input.GetAxis(GameInput.GetInput(GameInput.PlayerInput.Attack)) > 0)
                {
                    RangedAttack.FIRE(this);
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.Space)) RangedAttack.FIRE(this);
            }

        }

        public override void Destroyed()
        {
            base.Destroyed();
            GameManager.Instance.EffectSpawner.Spawn(Controllers.Effects.EffectType.BloodExplosion, transform.position);
            Destroy(gameObject);
        }
    }
}
