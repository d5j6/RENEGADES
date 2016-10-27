//Unity
using UnityEngine;
using UnityEngine.EventSystems;

//C#
using System.Collections;

namespace RENEGADES.UI.MainMenu
{
    /// <summary>
    /// Attach to each UI Panel to make sure a UI element is selectedfor the Xbox Controller
    /// </summary>
    public class SetFirstSelected : MonoBehaviour
    {

        private EventSystem eventSystem;
        private EventSystem _EventSystem
        {
            get { return eventSystem ?? (eventSystem = FindObjectOfType<EventSystem>()); }
        }

        public GameObject firstSelected;

        private void Awake()
        {
            StartCoroutine(Refresh());
        }

        private IEnumerator Refresh()
        {
            _EventSystem.firstSelectedGameObject = null;
            yield return new WaitForEndOfFrame();
            _EventSystem.firstSelectedGameObject = firstSelected;
        }

    }
}
