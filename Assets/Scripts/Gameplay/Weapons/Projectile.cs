using UnityEngine;

namespace RENEGADES.Gameplay.Weapons
{
    public class Projectile : MonoBehaviour
    {
        private Rigidbody2D rigid;
        private Rigidbody2D ElementRigidBody
        {
            get { return rigid ?? (rigid = GetComponent<Rigidbody2D>()); }
        }


        private const float lifeTime = 3.0f;
        private float moveSpeed;
        private Vector3 moveDirection;

        private void Awake()
        {
            Invoke("Dispose", lifeTime);
        }

        public void SetPosition(Vector3 pos)
        {
            transform.position = pos;
        }

        public void SetEulerAngle(float e)
        {
            transform.eulerAngles = new Vector3(0, 0, e);
        }

        public void SetMoveSpeed(float s)
        {
            moveSpeed = s;
        }

        public void SetMoveDirection(Vector3 v)
        {
            moveDirection = v;
        }

        public void Update()
        {
            ElementRigidBody.AddForce(moveDirection * moveSpeed);
            ElementRigidBody.velocity = Vector3.ClampMagnitude(ElementRigidBody.velocity, moveSpeed);
        }

        public virtual void OnTriggerEnter2D(Collider2D other)
        {
            Dispose();
            Debug.Log("HERE");
        }


        private void Dispose()
        {
            Destroy(gameObject);
        }

        private void OnDestory()
        {
            CancelInvoke();
        }
    }
}
