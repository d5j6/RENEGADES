//App
using RENEGADES.Managers;

namespace RENEGADES.Gameplay.AI
{
    public class DeadState : IEnemyState
    {

        private readonly Enemy enemy;

        private bool isDead = false;

        public DeadState(Enemy enemy)
        {
            this.enemy = enemy;
        }

        public void UpdateState()
        {
            if (isDead) return;
            Dead();
        }

        public void ToWalkState()
        {
           //we are already dead
        }

        public void ToAttackState()
        {
           //already dead
        }

        public void ToDeadState()
        {
            //were dead
        }

        private void Dead()
        {
            isDead = true;
            //spawn blood explosion
            GameManager.Instance.EffectSpawner.Spawn(Controllers.Effects.EffectType.BloodExplosion, enemy.transform.position);
            enemy.RemoveFromBattleField();
        }


    }
}
