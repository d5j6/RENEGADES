//App
using RENEGADES.Constants;
using RENEGADES.Gameplay.Players;
using RENEGADES.Managers;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Weapons
{
    public class RangedAttack : MonoBehaviour
    {

        public RangedElement element;

        private const float COOLDOWN = 0.25f;
        public float timer;

        private bool coolingDown;

        private AnimationTriggers.AnimationTrigger currentTrigger;

        private void Update()
        {
            Cooldown();
        }

        private void Cooldown()
        {
            if (!coolingDown) return;
            timer += Time.deltaTime;
            if (timer > COOLDOWN)
            {
                coolingDown = false;
                timer = 0.0f;
            }
        }

        public void FIRE(Player p)
        {
            currentTrigger = p.CurrentTrigger;
            if (coolingDown) return;
            coolingDown = true;
            Spawn();
        }

        private void Spawn()
        {
            
            RangedElement spawn = Instantiate(element);
            spawn.transform.position = transform.position;
            spawn.transform.localEulerAngles = SetPosition(spawn);
            GameManager.Instance.AudioManager.PlaySound(Audio.Sounds.Sound.Bullet_Fire, spawn.transform.position);
        }

        private Vector3 SetPosition(RangedElement spawn)
        {
            float eulerAngle = 0;
            Vector3 moveDirection = Vector3.zero;
            switch(currentTrigger)
            {
                case AnimationTriggers.AnimationTrigger.Down:
                    eulerAngle = 180;
                    moveDirection = Vector3.down;
                    break;
                case AnimationTriggers.AnimationTrigger.Left:
                    eulerAngle =90;
                    moveDirection = Vector3.left;
                    break;
                case AnimationTriggers.AnimationTrigger.Right:
                    eulerAngle = 270;
                    moveDirection = Vector3.right;
                    break;
                case AnimationTriggers.AnimationTrigger.Up:
                    eulerAngle = 0;
                    moveDirection = Vector3.up;
                    break;
            }
            spawn.SetMoveDirection(moveDirection);
            return new Vector3(spawn.transform.localEulerAngles.x, spawn.transform.localEulerAngles.y, eulerAngle);
        }

       
    }
}
