//App
using RENEGADES.Managers;
using RENEGADES.Constants;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Weapons
{
    public class RangedElement : MonoBehaviour
    {
        private Vector3 moveDirection;

        private const float MOVESPEED =12;

        public void Init(Vector3 pos)
        {
            transform.position = pos;
            GameManager.Instance.AudioManager.PlaySound(Audio.Sounds.Sound.Bullet_Fire, transform.position);
        }

        public void SetEulerAngles(AnimationTriggers.AnimationTrigger t)
        {
            transform.localEulerAngles = SetPosition(t);
        }

        public void SetMoveDirection(Vector3 v)
        {
            moveDirection = v;
            Invoke("Destroy", 2.0f);
        }

        public void Update()
        {
            transform.position += moveDirection * Time.deltaTime* MOVESPEED;
        }

        private void Destroy()
        {
            gameObject.SetActive(false);
        }

        public Vector3 SetPosition(AnimationTriggers.AnimationTrigger currentTrigger)
        {
            float eulerAngle = 0;
            Vector3 moveDirection = Vector3.zero;
            switch (currentTrigger)
            {
                case AnimationTriggers.AnimationTrigger.Down:
                    eulerAngle = 180;
                    moveDirection = Vector3.down;
                    break;
                case AnimationTriggers.AnimationTrigger.Left:
                    eulerAngle = 90;
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
            SetMoveDirection(moveDirection);
            return new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, eulerAngle);
        }

    }
}
