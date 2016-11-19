//App
using RENEGADES.UI.Gameplay;
using RENEGADES.Gameplay.Basic;
using RENEGADES.Constants;
using RENEGADES.Managers;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Players
{
    /// <summary>
    /// base player class, controlling movement and animation and player UI top leave
    /// </summary>
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

        private AnimationTriggers.PlayerAnimation currentTrigger;
        public AnimationTriggers.PlayerAnimation CurrentTrigger
        {
            get { return currentTrigger; }
        }

        private PlayerModule playerHUD;
        public PlayerModule PlayerHUD
        {
            get { return playerHUD; } set { playerHUD = value; }
        }

        private int CRYSTALS;
        private int PLAYER_NUMBER = 1;

        public void SetPlayerNumber(int num)
        {
            PLAYER_NUMBER = num;
        }

        public int GetPlayerNumber()
        {
            return PLAYER_NUMBER;
        }

        public override void SetHealth(float h)
        {
            base.SetHealth(100);
            UpdateCrystals(20);
            if(playerHUD != null) PlayerHUD.SetMaxHealth(100);
        }

        public override void ChangeHealth(float health)
        {
            base.ChangeHealth(health);
            if (playerHUD != null) PlayerHUD.UpdateHealth(HEALTH);
        }

        public void UpdateCrystals(int amount)
        {
            CRYSTALS += amount;
            if (playerHUD != null) PlayerHUD.UpdateCrystal(CRYSTALS);
        }

        public float GetCrystals()
        {
            return CRYSTALS;
        }

        //player main game loop
        private void FixedUpdate()
        {
            AnimationLoop();
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


        public override void Destroyed()
        {
            base.Destroyed();
            GameManager.Instance.EffectSpawner.CreateEffect(EffectBlueprint.EffectType.BloodExplosion, transform.position);
            Destroy(gameObject);
        }
    }
}
