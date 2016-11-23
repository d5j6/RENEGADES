//Game
using RENEGADES.Managers;
using RENEGADES.Constants;

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

        private float Axis;

        private void Update()
        {
            MoveController();
        }

        private void MoveController()
        {
            if(GameManager.Instance._ControllerManager.AnyControllersConnected()) //Make Sure Controllers are connected
            {
                Axis += Input.GetAxis(GameInput.GetInput(player, GameInput.PlayerInput.MovementX));
                Axis = Mathf.Clamp(Axis, -1, 1);
                Selection.NotifyChange(Axis, player,0.9f,1);
            }
            else
            {
                if (player == 2) return;
                Selection.NotifyChange(Input.mousePosition.x - (0.5f * Screen.width),player,75,Screen.width);
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
