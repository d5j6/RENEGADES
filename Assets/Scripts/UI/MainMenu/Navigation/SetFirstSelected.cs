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

        public GameObject firstSelected;

        private void Awake()
        {
            StartCoroutine(Refresh());
        }

        private IEnumerator Refresh()
        {
            yield return null;
            EventSystem.current.SetSelectedGameObject(firstSelected, new BaseEventData(EventSystem.current));

        }

    }
}
