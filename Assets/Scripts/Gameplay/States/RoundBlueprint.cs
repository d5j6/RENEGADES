
namespace RENEGADES.Gameplay.States
{
    /// <summary>
    /// Class that will be used to determine what happens in a round
    /// Monsters spawned, etc
    /// </summary>
    public class RoundBlueprint
    {
        private int round;

        private const int timeBetweenRounds = 5;

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

        public int GetTimeBetweenRound()
        {
            return timeBetweenRounds;
        }

    }
}
