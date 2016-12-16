//Game
using RENEGADES.Managers;
using RENEGADES.UI.InGame.PopUps;

//C#
using System;
using System.Collections;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.States
{
    public class RechargeState : IGameState
    {
        private GameController gameController;

        private float roundTimer;

        public RechargeState(GameController controller)
        {
            gameController = controller;
        }

        /// <summary>
        /// Called on State Start
        /// </summary>
        public void Begin()
        {
            roundTimer = 0;
            NewRoundUI newRoundTxt = GameManager.Instance.UISpawner.CreateWidget(UI.Managers.WidgetCreator.WidgetToSpawn.RoundText) as NewRoundUI;
            newRoundTxt.SetContent(gameController.GetBluePrint().GetTimeBetweenRound(), gameController.GetBluePrint().GetRound());
        }


        public void Battle()
        {
            gameController.Change_State(gameController._BattleState);
        }

        public void GameOver()
        {
            gameController.Change_State(gameController._GameOverState);
        }

        public void Recharge()
        {
            //Will never get called
        }

        public void OnUpdate()
        {
            if (gameController.GameOver()) { GameOver(); return; }
            roundTimer += Time.deltaTime;
            if (roundTimer > gameController.GetBluePrint().GetTimeBetweenRound()) { Battle(); }
        }


    }
}
