
using UnityEngine;

namespace RENEGADES.Gameplay.Weapons
{
    public class Lancer : Projectile
    {
        public override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
           // Dispose();


        }

        public override void Dispose()
        {
            base.Dispose();
        }

    }
}
