//App
using RENEGADES.UI.Effects;
using RENEGADES.Managers;

//Unity
using UnityEngine;

//C#
using System.Collections.Generic;
using System.Linq;

namespace RENEGADES.UI.Connection
{
    public class ConnectionBar : MonoBehaviour
    {

        private List<ControllerConnect> connectionUIs;
        private List<ControllerConnect> ConnectionUIs
        {
            get { return connectionUIs ?? (connectionUIs = GetComponentsInChildren<ControllerConnect>().ToList()); }
        }

        private ColorChange colChange;
        private ColorChange ColChange
        {
            get { return colChange ?? (colChange = GetComponent<ColorChange>()); }
        }

        private float CONNECTIONCHECK_REFRESHRATE = 0.35f;

        private Color32 noConnectionColor = new Color32(255, 98, 98, 255);
        private Color32 connectionColor = new Color32(85, 116, 93, 255);

        private int CurrentplayerCount;

        private void Awake()
        {
            NoConnection();
            InvokeRepeating("CheckConnection", 0, CONNECTIONCHECK_REFRESHRATE); //check for controls every so seconds
        }

        private void CheckConnection()
        {
            //check if our system has a new controller plugged in or out
            int currentPlayers = GameManager.Instance.ControllerManager.GetPlayerCount();
            if (currentPlayers != CurrentplayerCount)
            {
                CurrentplayerCount = currentPlayers;
                if (currentPlayers == 0) NoConnection();
                else if (currentPlayers == 1) { OnePlayerFound(); }
                else { TwoPlayersFound(); }
            }
        }

        private void OnePlayerFound()
        {
            ColChange.ColorTo(connectionColor);
            ConnectionUIs[0].CONNECTED(); ConnectionUIs[1].DISCONNECTED();
        }

        private void TwoPlayersFound()
        {
            ColChange.ColorTo(connectionColor);
            ConnectionUIs.ForEach(x => x.CONNECTED());
        }

        private void NoConnection()
        {
            ColChange.ColorTo(noConnectionColor);
            ConnectionUIs.ForEach(x => x.DISCONNECTED());
        }

        private void OnDestroy()
        {
            CancelInvoke("CheckConnection");
            connectionUIs = null;
        }
    }
}
