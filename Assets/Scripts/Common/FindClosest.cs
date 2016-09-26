//UnityEngine
using UnityEngine;

namespace RENEGADES.Common
{
    public class FindClosest
    {
        //fill find closest to the transform of 
        public static T Find<T>(Transform t) where T : Component
        {
            T[] elements = Object.FindObjectsOfType<T>();

            float closestDistance = Mathf.Infinity;
            T closest = null;
            foreach (T e in elements)
            {
                float distance = (t.position - e.transform.position).sqrMagnitude;
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closest = e;
                }
            }
            return closest;
        }
    }
}
