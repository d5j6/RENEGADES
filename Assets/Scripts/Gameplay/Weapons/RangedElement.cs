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

        private const float MOVESPEED =150;

        private Rigidbody2D rigid;
        private Rigidbody2D ElementRigidBody
        {
            get { return rigid ?? (rigid = GetComponent<Rigidbody2D>()); }
        }

        public void Init(Vector3 pos)
        {
            transform.position = pos;
            GameManager.Instance.AudioManager.PlaySound(Audio.Sounds.Sound.Bullet_Fire, transform.position);
        }

        public void SetEulerAngles(AnimationTriggers.PlayerAnimation t)
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
            ElementRigidBody.AddForce(moveDirection* MOVESPEED);
            ElementRigidBody.velocity = Vector3.ClampMagnitude(ElementRigidBody.velocity, MOVESPEED);
        }

        private void Destroy()
        {
            ElementRigidBody.velocity = new Vector2(0,0);
            CancelInvoke("Destroy");
            gameObject.SetActive(false);
        }

        public Vector3 SetPosition(AnimationTriggers.PlayerAnimation currentTrigger)
        {
            float eulerAngle = 0;
            Vector3 moveDirection = Vector3.zero;
            switch (currentTrigger)
            {
                case AnimationTriggers.PlayerAnimation.Down:
                    eulerAngle = 180;
                    moveDirection = Vector3.down;
                    break;
                case AnimationTriggers.PlayerAnimation.Left:
                    eulerAngle = 90;
                    moveDirection = Vector3.left;
                    break;
                case AnimationTriggers.PlayerAnimation.Right:
                    eulerAngle = 270;
                    moveDirection = Vector3.right;
                    break;
                case AnimationTriggers.PlayerAnimation.Up:
                    eulerAngle = 0;
                    moveDirection = Vector3.up;
                    break;
            }
            SetMoveDirection(moveDirection);
            return new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, eulerAngle);
        }

        public virtual void OnTriggerEnter2D(Collider2D other)
        {
            Destroy();
        }

    }
}
