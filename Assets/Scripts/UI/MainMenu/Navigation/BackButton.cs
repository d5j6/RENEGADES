//Game
using RENEGADES.Constants;

//Unity
using UnityEngine;

namespace RENEGADES.UI.MainMenu.Navigation
{
    /// <summary>
    /// If there is a black button clicking B on the joystick will go back
    /// </summary>
    public class BackButton : NavButton
    {
        public override void OnUpdate()
        {
            base.OnUpdate();
            if(Input.GetButtonDown(GameInput.GetInput(1,GameInput.PlayerInput.BButton)))
            {
                Button_OnSelected();
            }
        }
    }
}
