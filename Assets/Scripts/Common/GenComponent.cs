//Unity
using UnityEngine;

namespace RENEGADES.Common
{
    public class GenComponent
    {
        public static T ComponentCheck<T>(GameObject obj) where T : Component
        {
            if (obj.GetComponent(typeof(T)) == null)
            {

                obj.AddComponent(typeof(T));
            }

            return obj.GetComponent(typeof(T)) as T;
        }
    }
}
