//App
using RENEGADES.Common;
using RENEGADES.Gameplay.Input;

//Unity
using UnityEngine;


namespace RENEGADES.Managers
{
    //singleton game manager
    public class GameManager : Singleton<GameManager>
    {
        private ControllerManager controllerManager;
        public ControllerManager ControllerManager
        {
            get { return controllerManager ?? (controllerManager = GetComponentInChildren<ControllerManager>()); }
        }

        private void OnDestroy()
        {
            controllerManager = null;
        }
    }
}
