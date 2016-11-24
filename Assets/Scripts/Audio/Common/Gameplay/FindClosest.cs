//UnityEngine
using UnityEngine;

//C#
using System.Collections.Generic;

namespace RENEGADES.Common.Gameplay
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

        //fill find closest to the transform of with a range
        public static T Find<T>(Transform t,float range) where T : Component
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
            if (closestDistance > range) return default(T);
            return closest;
        }

        //fill find closest to the transform of with a range
        public static Dictionary<T,float> Find_Group<T>(Transform t, float range) where T : Component
        {
            T[] elements = Object.FindObjectsOfType<T>();
            Dictionary<T, float> hash = new Dictionary<T, float>();
            foreach (T e in elements)
            {
                float distance = (t.position - e.transform.position).sqrMagnitude;

                if (distance < range)
                {
                    hash.Add(e, distance);
                    
                }
            }

            return hash;
        }
    }
}
