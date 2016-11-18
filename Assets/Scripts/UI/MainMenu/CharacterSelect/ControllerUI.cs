﻿//Game
using RENEGADES.Managers;

//Unity
using UnityEngine;

namespace RENEGADES.UI.MainMenu.CharacterSelect
{
    public class ControllerUI : MonoBehaviour
    {
        [Header("Player Number")]
        [Tooltip("Which Player Does this Controller Belong to")]
        [Range(1,2)]
        public int player;

        private CharacterSelect selection;
        private CharacterSelect Selection
        {
            get { return selection ?? (selection = GetComponentInParent<CharacterSelect>()); }
        }

        private CharacterDisplay currentCharacter;

        private void Update()
        {
            MoveController();
        }

        private void MoveController()
        {
            if(GameManager.Instance._ControllerManager.GetControllerCount() > 0) //Make Sure Controllers are connected
            {

            }
            else
            {
                if (player == 2) return;
                Selection.NotifyChange(Input.mousePosition.x - (0.5f * Screen.width),player);
            }
        }

        public CharacterDisplay GetCharacter()
        {
            return currentCharacter;
        }

        public void SetCharacter(CharacterDisplay character)
        {
            currentCharacter = character;
        }

    }
}
