﻿//Game
using RENEGADES.Managers;
using RENEGADES.Constants;
using RENEGADES.UI.MainMenu.Navigation;

//Unity
using UnityEngine;

namespace RENEGADES.UI.MainMenu.CharacterSelect
{
    public class CharacterSelect : UIPanel
    {
        private CharacterDisplay[] characterDisplays;
        private CharacterDisplay[] CharacterDisplays
        {
            get { return characterDisplays ?? (characterDisplays = GetComponentsInChildren<CharacterDisplay>()); }
        }

        private ControllerUI[] controllerUIs;
        private ControllerUI[] ControllerUIs
        {
            get { return controllerUIs ?? (controllerUIs = GetComponentsInChildren<ControllerUI>()); }
        }

        [Header("Display Colors")]
        public Color textSelectedColor;
        public Color textDeSelectedColor;
        public Color imageSelectedColor;
        public Color imageDeSelectedColor;

        public override void Init()
        {
            base.Init();
            if (ControllerUIs.Length < 2 || CharacterDisplays.Length < 2) Debug.LogError("You are missing Controller or Char Display UI Elements in this Panel. It will not function properly");
        }

        /// <summary>
        /// Controls selection of placers
        /// </summary>
        /// <param name="axis">Axis that is being used by controller</param>
        /// <param name="player">player number</param>
        /// <param name="midBound">middle bound of axis</param>
        /// <param name="outerBound">high bound of axis</param>
        public void NotifyChange(float axis, int player,float midBound,float outerBound)
        {
            //Get Character selected
            CharacterDisplay character = null;
            if (axis <= outerBound  && axis > midBound) character = CharacterDisplays[1];
            else if (axis >= -outerBound && axis < -midBound) character =CharacterDisplays[0];

            ControllerUI control = ControllerUIs[player - 1];
            //Move Controller to Place
            control.transform.localPosition = (character != null)
                ? new Vector3(character.GetPos().x, control.transform.localPosition.y, 0)
                : new Vector3(0, control.transform.localPosition.y, 0);
       

            //update character control
            if (control.GetCharacter() != character)
            {
                if (control.GetCharacter() != null) control.GetCharacter().UpdateControllCount(-1);
                control.SetCharacter(character);
                if (control.GetCharacter() != null)
                {
                    control.GetCharacter().UpdateControllCount(1);     
                }
            }

        }


        //Look for player to start game
        public override void OnUpdate()
        {
            base.OnUpdate();
            if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown(GameInput.GetInput(1,GameInput.PlayerInput.AButton))) GAMEPREP();
        }

        //Prep Players in game 
        private void GAMEPREP()
        {
            int validControllers = 0;
            for(int i=0; i < ControllerUIs.Length;i++)
            {
                if(ControllerUIs[i].GetCharacter() != null)
                {
                    GameManager.Instance._GameSettings.SetPlayerType(i+1, ControllerUIs[i].GetCharacter().playerType);//Set PLAYER in SETTING
                    validControllers++;
                }
                else
                {
                    GameManager.Instance._GameSettings.RemovePlayer(i + 1);
                }
            }
            if (validControllers > 0) LAUNCH();
        }

        //Launch Game
        private void LAUNCH()
        {
            GameManager.Instance._LevelLoad.LoadLevel(LevelLoader.Levels.Game);
        }

    }
}
