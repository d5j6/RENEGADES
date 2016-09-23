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

        public void Walking()
        {
            enemy.CurrentState = enemy._WalkingState;
        }

        public void Attacking()
        {
            //This is the attacking state!
        }

    }
}
