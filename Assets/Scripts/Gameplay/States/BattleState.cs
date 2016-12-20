//Unity
using UnityEngine;

//Game
using RENEGADES.Gameplay.AI.Monsters;
using RENEGADES.Managers;

namespace RENEGADES.Gameplay.States
{
    /// <summary>
    /// Main Gameplay state of game that spawns enemies
    /// </summary>
    public class BattleState : IGameState
    {
        private GameController gameController;

        private float enemyTimer;
        private float genResetTime;
        private int enemyCounter;

        public BattleState(GameController controller)
        {
            gameController = controller;
        }

        /// <summary>
        /// Called on State Start
        /// </summary>
        public void Begin()
        {
            enemyCounter = 0;
            genResetTime = gameController.GetBluePrint().GetTimeUntilNextGen();
        }

        public void Battle()
        {
            //Will never get called
        }

        public void GameOver()
        {
            gameController.Change_State(gameController._GameOverState);
        }

        public void Recharge()
        {
            gameController.GetBluePrint().IncrementRound();
            gameController.Change_State(gameController._RechargeState);
        }

        public void OnUpdate()
        {
            if (gameController.GameOver()) { GameOver(); return; }
            if (gameController.GetBluePrint().AllEnemiesDefeated()) { Recharge(); return; }
            SpawnTheHorde();

        }

        private void SpawnTheHorde()
        {
            //weve spawned our alloted enemies
            if (enemyCounter == gameController.GetBluePrint().GetEnemyCount()) { return; }
            enemyTimer += Time.deltaTime;
            if (enemyTimer > genResetTime)
            {
                int type = Random.Range(0, 11);
                MonsterBlueprint.EnemyType t = type > 7 ? type > 9 ? MonsterBlueprint.EnemyType.Gorgan : MonsterBlueprint.EnemyType.Soldier : MonsterBlueprint.EnemyType.Ghoul;
                GameManager.Instance.MonsterSpawner.CreateMonster(t);
                enemyTimer = 0;
                genResetTime = gameController.GetBluePrint().GetTimeUntilNextGen();
                enemyCounter++;
            }
        }

    }
}
