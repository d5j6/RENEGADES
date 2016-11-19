/// <summary>
/// Interface for Gameplay States
/// </summary>
/// 
namespace RENEGADES.Gameplay.States
{
    public interface IGameState
    {

        void OnUpdate();
        void GameOver();
        void Recharge();
        void Battle();

    }
}
