//Game
using RENEGADES.Managers;

namespace RENEGADES.UI.MainMenu.Welcome
{
    public class Welcome : UIPanel
    {
        private bool clicked = false;

        public override void Init()
        {
            base.Init();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (clicked) return;
            if(UnityEngine.Input.anyKey)
            {
                clicked = true;
                StartCoroutine(GameManager.Instance.MainMenu.TRANSITION(Navigation.NavigationController.Place.MainMenuPage));
            }
        }

    }
}
