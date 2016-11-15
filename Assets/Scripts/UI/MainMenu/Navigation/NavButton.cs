//Unity
using UnityEngine;

//Game
using RENEGADES.Managers;
using GameEngineering.Common.UI;

namespace RENEGADES.UI.MainMenu.Navigation
{
    public class NavButton : GenericButton
    {

        public NavigationController.Place navPlace;

        public override void Button_OnSelected()
        {
            base.Button_OnSelected();
            EnableInteraction(false);
            GameManager.Instance.AudioManager.PlaySound(Audio.Sounds.Sound.MainMenuClick);
            StartCoroutine(GameManager.Instance.MainMenu.TRANSITION(navPlace));
            if (navPlace == NavigationController.Place.QuitPage) Invoke("QUIT", 1.5f);

        }

        private void QUIT()
        {
            Application.Quit();
        }
    }
}
