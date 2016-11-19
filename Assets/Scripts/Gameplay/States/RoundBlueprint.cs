
namespace RENEGADES.Gameplay.States
{
    /// <summary>
    /// Class that will be used to determine what happens in a round
    /// Monsters spawned, etc
    /// </summary>
    public class RoundBlueprint
    {
        private int round;
        public RoundBlueprint()
        {
            round = 1;
        }

        public int GetRound()
        {
            return round;
        }

        public void IncrementRound()
        {
            round++;
        }
    }
}
