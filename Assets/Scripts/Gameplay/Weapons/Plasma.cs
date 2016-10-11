//App
using RENEGADES.Managers;
using RENEGADES.Constants;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Weapons
{
    public class Plasma : Projectile
    {
        private const float MOVESPEED =150;

        public void Init(Vector3 pos)
        {
            transform.position = pos;
            GameManager.Instance.AudioManager.PlaySound(Audio.Sounds.Sound.Bullet_Fire, transform.position);
        }

        public void SetEulerAngles(AnimationTriggers.PlayerAnimation t)
        {
            transform.localEulerAngles = SetPosition(t);
        }

        public override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            Dispose();
        }

        public Vector3 SetPosition(AnimationTriggers.PlayerAnimation currentTrigger)
        {
            float eulerAngle = 0;
            Vector3 direction = Vector3.zero;
            switch (currentTrigger)
            {
                case AnimationTriggers.PlayerAnimation.Down:
                    eulerAngle = 180;
                    direction = Vector3.down;
                    break;
                case AnimationTriggers.PlayerAnimation.Left:
                    eulerAngle = 90;
                    direction = Vector3.left;
                    break;
                case AnimationTriggers.PlayerAnimation.Right:
                    eulerAngle = 270;
                    direction = Vector3.right;
                    break;
                case AnimationTriggers.PlayerAnimation.Up:
                    eulerAngle = 0;
                    direction = Vector3.up;
                    break;
            }
            SetMoveDirection(direction);
            return new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, eulerAngle);
        }

        public override void Dispose()
        {
            base.Dispose();
            gameObject.SetActive(false);
        }

    }
}
