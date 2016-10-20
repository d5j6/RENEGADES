//App
using RENEGADES.Managers;

//Unity

namespace RENEGADES.Gameplay.AI
{
    public class Ghoul : MonsterAI
    {
        //set custom speed for ghoul
        private const float GHOUL_SPEED = 1;
        private const int GHOUL_HEALTH = 10;
        private const float GHOUL_ATTACKRANGE = 0.5f;
        private const float GHOUL_ATTACKSPEED = 0.5f;
        private const float GHOUL_DAMAGE = 10.0f;

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
            base.SetAttackRange(GHOUL_ATTACKRANGE);
        }

        public override void SetAttackSpeed(float s)
        {
            base.SetAttackSpeed(GHOUL_ATTACKSPEED);
        }

        public override void SetDamage(float d)
        {
            base.SetDamage(GHOUL_DAMAGE);
        }

        public override void SetDifficulty(DIFFICULTY d)
        {
            base.SetDifficulty(DIFFICULTY.Easy);
        }

        public override void RemoveFromBattleField()
        {
            base.RemoveFromBattleField();
            GameManager.Instance.AudioManager.PlaySound(Audio.Sounds.Sound.GhoulDeath);
        }
    }
}
