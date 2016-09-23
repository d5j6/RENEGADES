namespace RENEGADES.Gameplay.AI
{
    //interface for enemy states
    public interface IEnemyState 
    {
        void UpdateState();

        void Walking();

        void Attacking();

    }
}
