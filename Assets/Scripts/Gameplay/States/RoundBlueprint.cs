//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.States
{
    /// <summary>
    /// Class that will be used to determine what happens in a round
    /// Monsters spawned, etc
    /// </summary>
    public class RoundBlueprint
    {
        private int round;
        private int enemyCount;
        private float genMaxTime;

        private const int timeBetweenRounds = 4;
        private const int gameOverTime = 5;

        public RoundBlueprint()
        {
            round = 1;
            enemyCount = 1;
            genMaxTime = 3;
        }

        public int GetRound()
        {
            return round;
        }

        public void IncrementRound()
        {
            round++;
            enemyCount += Random.Range(1, 5);
            genMaxTime -= Random.Range(0.1f, 0.2f);
        }

        public int GetTimeBetweenRound()
        {
            return timeBetweenRounds;
        }

        public int GetGameOverTime()
        {
            return gameOverTime;
        }

        public int GetEnemyCount()
        {
            return enemyCount;
        }

        public float GetTimeUntilNextGen()
        {
            return Mathf.Clamp(Random.Range(0.0f, genMaxTime),0,10);
        }

    }
}
