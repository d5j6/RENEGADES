
using UnityEngine;

namespace RENEGADES.Gameplay.Weapons
{
    public class Lancer : Projectile
    {
        public override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
           
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        //    RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.forward, Mathf.Infinity, 1 << 12);

        }

        public override void Dispose()
        {
            Destroy(gameObject);
        }

    }
}
