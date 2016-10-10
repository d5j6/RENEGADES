namespace RENEGADES.Gameplay.AI
{
    //interface for enemy states
    public interface IEnemyState 
    {
        void UpdateState();

        void ToWalkState();

        void ToAttackState();

        void ToDeadState();

        void SetUp();

    }
}
