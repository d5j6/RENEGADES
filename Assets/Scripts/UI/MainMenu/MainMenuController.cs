//Unity
using UnityEngine;

//Game
using RENEGADES.Gameplay.Generators;
using RENEGADES.UI.MainMenu.Navigation;

//C#
using System;
using System.Collections;
using System.Collections.Generic;


namespace RENEGADES.UI.MainMenu
{
    public class MainMenuController : Spawner
    {
        [Serializable]
        public struct Panel
        {
           public string name;
           public NavigationController.Place key;
           public UIPanel prefab;
        }

        public List<Panel> UIPanels;

        private NavigationController navController;
        private NavigationController NavController
        {
            get { return navController ?? (navController = FindObjectOfType<NavigationController>()); }
        }

        private Dictionary<NavigationController.Place, UIPanel> Lookup;

        private UIPanel currentPANEL;

        public override void Init()
        {
            if (FindObjectOfType<UIPanel>()) Destroy(FindObjectOfType<UIPanel>().gameObject);
            SetUp();
            NavController.SetUp();
            StartCoroutine(TRANSITION(NavigationController.Place.WelcomePage));
        }

        private void SetUp()
        {
            Lookup = new Dictionary<NavigationController.Place, UIPanel>();
            foreach(Panel p in UIPanels)
            {
                if(!Lookup.ContainsKey(p.key))Lookup.Add(p.key, p.prefab);
            }
        }

        public IEnumerator TRANSITION(NavigationController.Place place)
        {
            if (currentPANEL != null) currentPANEL.Disable();
            yield return new WaitForSeconds(NavController.Travel(place));
            if (currentPANEL != null) Destroy(currentPANEL.gameObject);
            currentPANEL = SpawnUI(Lookup[place]) as UIPanel;

        }

        private void OnDestroy()
        {
            Lookup.Clear();
            Lookup = null;
        }
    }
}
