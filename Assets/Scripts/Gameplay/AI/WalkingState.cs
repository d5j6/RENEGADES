namespace RENEGADES.Gameplay.AI
{

    public class WalkingState : IEnemyState
    {

        private readonly Enemy enemy;

        public WalkingState(Enemy enemy)
        {
            this.enemy = enemy;
        }

        public void UpdateState()
        {

        }

        public void Walking()
        {
          //We are already walking
        }

        public void Attacking()
        {
            enemy.CurrentState = enemy._AttackingState;
        }
    }
}
