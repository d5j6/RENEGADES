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

        }

        public void ToWalkState()
        {
            enemy.CurrentState = enemy._WalkingState;
        }

        public void ToAttackState()
        {
            //This is the attacking state!
        }

    }
}
