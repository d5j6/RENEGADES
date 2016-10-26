//Unity
using UnityEngine;

//C#
using System.Collections.Generic;

namespace RENEGADES.UI.MainMenu.Navigation
{
    public class NavigationController : MonoBehaviour
    {
        public enum Place
        {
            WelcomePage,
            MainMenuPage,
            CharacterSelectPage,
            HighScoresPage,
            SettingsPage,
            CreditsPage,
            QuitPage
        }

        public class VectorParams
        {
            public Vector3 position;
            public Vector3 eulerAngle;
            public VectorParams (Vector3 p,Vector3 e) { position = p; eulerAngle = e; }
        }

        private Dictionary<Place,VectorParams> placeLookup;

        private const float MOVE_TIME = 2.0f;
        private const float ROTATE_TIME = 1.5f;
        private const iTween.EaseType MOVE_EASETYPE = iTween.EaseType.easeInOutQuad;
        private const iTween.EaseType ROTATE_EASETYPE = iTween.EaseType.easeInOutQuad;

        public void SetUp()
        {
            placeLookup = new Dictionary<Place, VectorParams>();
            foreach(NavigationPoint point in GetComponentsInChildren<NavigationPoint>())
            {
                placeLookup.Add(point.GetPlace(), new VectorParams(point.GetPosition(),point.GetEulerAngle())); 
            }
        }

        public float Travel(Place place)
        {
            MoveTo(placeLookup[place].position);
            RotateTo(placeLookup[place].eulerAngle);
            return (MOVE_TIME >= ROTATE_TIME) ? MOVE_TIME : ROTATE_TIME;
        }

        private void MoveTo(Vector3 pos)
        {
            iTween.MoveTo(Camera.main.gameObject, iTween.Hash("islocal", true, 
                  "position", pos, 
                  "time", MOVE_TIME, 
                  "easetype", MOVE_EASETYPE, 
                  "oncomplete", "Animation_OnCompleted", 
                  "oncompletetarget", gameObject));
        }

        private void RotateTo(Vector3 euler)
        {
            iTween.RotateTo(Camera.main.gameObject, iTween.Hash("islocal", true,
                 "rotation", euler,
                 "time", ROTATE_TIME,
                 "easetype", ROTATE_EASETYPE,
                 "oncomplete", "Animation_OnCompleted",
                 "oncompletetarget", gameObject));
        }

        private void OnDestroy()
        {
            placeLookup.Clear();
            placeLookup = null;
        }

    }
}
