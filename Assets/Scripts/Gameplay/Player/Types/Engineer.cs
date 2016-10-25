//Unity
using UnityEngine;

//Game
using RENEGADES.Gameplay.Weapons.Turrets;
using RENEGADES.Constants;
using RENEGADES.Managers;

namespace RENEGADES.Gameplay.Players.Types
{
    public class Engineer : Player
    {
        private TurretBuilder builder;
        private TurretBuilder Builder
        {
            get { return builder ?? (builder = GetComponentInChildren<TurretBuilder>()); }
        }

        public override void Init()
        {
            base.Init();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            BuildTurretLoop();
        }

        private void BuildTurretLoop()
        {
            if (GameManager.Instance._ControllerManager.AnyControllersConnected())
            {
                Builder.Building((Input.GetAxis(GameInput.GetInput(GameInput.PlayerInput.CharacterSpecial)) > 0) ? true : false);
            }
            else
            {
                Builder.Building(Input.GetKey(KeyCode.X) ? true : false);
            }
        }

    }
}
