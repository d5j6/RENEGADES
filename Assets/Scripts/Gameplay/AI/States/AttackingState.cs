namespace RENEGADES.Gameplay.AI
{
    public class AttackingState : IEnemyState
    {
        private readonly Enemy enemy;

        public AttackingState (Enemy enemy)
        {
            this.enemy = enemy;
        }

        public void UpdateState()
        {
            if (enemy.HEALTH <= 0) ToDeadState();
        }

        public void ToWalkState()
        {
            enemy.CurrentState = enemy._WalkingState;
        }

        public void ToAttackState()
        {
            //This is the attacking state!
        }

        public void ToDeadState()
        {
            enemy.CurrentState = enemy._DeadState;
        }

    }
}
