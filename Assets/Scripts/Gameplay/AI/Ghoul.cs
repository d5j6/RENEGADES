//App
using RENEGADES.Managers;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.AI
{
    public class Ghoul : Enemy
    {
        //set custom speed for ghoul
        private const float GHOUL_SPEED = 5;
        private const int GHOUL_HEALTH = 10;
        private const float GHOUL_ATTACKRANGE = 0.65f;
        private const float GHOUL_ATTACKSPEED = 0.75f;

        public override void SetSpeed(float s)
        {
            base.SetSpeed(GHOUL_SPEED);
        }

        public override void SetHealth(float h)
        {
            base.SetHealth(GHOUL_HEALTH);
        }

        public override void SetAttackRange(float r)
        {
            base.SetAttackRange(GHOUL_ATTACKSPEED);
        }

        public override void SetAttackSpeed(float s)
        {
            base.SetAttackSpeed(GHOUL_ATTACKSPEED);
        }

        //in case we want anything extra to happen on collision for ghouls
        public override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
        }

        public override void RemoveFromBattleField()
        {
            base.RemoveFromBattleField();
            GameManager.Instance.AudioManager.PlaySound(Audio.Sounds.Sound.GhoulDeath);
        }
    }
}
