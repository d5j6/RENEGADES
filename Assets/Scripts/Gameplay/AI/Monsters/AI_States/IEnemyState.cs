namespace RENEGADES.Gameplay.AI.Monsters
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
