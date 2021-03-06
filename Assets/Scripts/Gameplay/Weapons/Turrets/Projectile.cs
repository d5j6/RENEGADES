﻿//Unity
using UnityEngine;

//Game
using GameEngineering.Common;

namespace RENEGADES.Gameplay.Weapons
{
    public class Projectile : PooledObject
    {
        private Rigidbody2D rigid;
        private Rigidbody2D ElementRigidBody
        {
            get { return rigid ?? (rigid = GetComponent<Rigidbody2D>()); }
        }

        private TrailRenderer trail;
        private TrailRenderer Trail
        {
            get { return trail ?? (trail = GetComponent<TrailRenderer>()); }
        }

        private const float lifeTime = 3.0f;
        private float lifeTimeTimer;
        private float moveSpeed;
        private Vector3 moveDirection;

        private float DAMAGE;

        public override void Show()
        {
            base.Show();
        }

        public override void Remove()
        {
            base.Remove();
            Trail.Clear();
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

        public void SetDamage(float d)
        {
            DAMAGE = d;
        }

        public float GetDamage()
        {
            return DAMAGE;
        }

        public void Update()
        {
            ElementRigidBody.AddForce(moveDirection * moveSpeed);
            ElementRigidBody.velocity = Vector3.ClampMagnitude(ElementRigidBody.velocity, moveSpeed);
            lifeTimeTimer += Time.deltaTime;
            if(lifeTimeTimer > lifeTime)
            {
                Dispose();
                lifeTimeTimer = 0;
            }
            OnUpdate();
        }

        public virtual void OnUpdate()
        {

        }

        public virtual void OnTriggerEnter2D(Collider2D other)
        {
            
        }


        public virtual void Dispose()
        {
            GetPooler().RemovePooledObject(this);
        }

        private void OnDestory()
        {
            CancelInvoke();
        }
    }
}
