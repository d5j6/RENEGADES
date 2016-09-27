//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.AI
{
    public class Ghoul : Enemy
    {
        //set custom speed for ghoul
        private const float GHOUL_SPEED = 5;
        private const int GHOUL_HEALTH = 10;

        public override void MOVE(float s)
        {
            base.MOVE(GHOUL_SPEED);
        }

        public override void SetHealth(float h)
        {
            base.SetHealth(GHOUL_HEALTH);
        }

        //in case we want anything extra to happen on collision for ghouls
        public override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
        }
    }
}
