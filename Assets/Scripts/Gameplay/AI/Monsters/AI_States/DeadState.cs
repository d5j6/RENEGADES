//App
using RENEGADES.Managers;

namespace RENEGADES.Gameplay.AI.Monsters
{
    public class DeadState : IEnemyState
    {

        private readonly MonsterAI enemy;

        private bool isDead = false;

        public DeadState(MonsterAI enemy)
        {
            this.enemy = enemy;
        }

        public void SetUp()
        {

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
            GameManager.Instance.EffectSpawner.CreateEffect(EffectBlueprint.EffectType.BloodExplosion, enemy.transform.position);
            enemy.RemoveFromBattleField();
        }


    }
}
