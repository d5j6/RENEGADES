//Unity
using UnityEngine;

namespace RENEGADES.UI.MainMenu.Navigation
{
    public class NavigationPoint : MonoBehaviour
    {

        [Header("Navigation Point for this")]
        public NavigationController.Place navigationPoint;

        public NavigationController.Place GetPlace()
        {
            return navigationPoint;
        }

        public Vector3 GetPosition()
        {
            return transform.localPosition;
        }

        public Vector3 GetEulerAngle()
        {
            return transform.localEulerAngles;
        }


    }
}
