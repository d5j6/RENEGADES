﻿//Unity
using UnityEngine;

namespace RENEGADES.Common
{
    //The following class will make any class that inherits from it a singleton automatically
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected static T instance;

        //Returns the instance of this singleton.
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = (T)FindObjectOfType(typeof(T));

                    if (instance == null)
                    {
                        Debug.LogError("An instance of " + typeof(T) +
                           " is needed in the scene, but there is none.");
                    }
                }

                return instance;
            }
        }
    }
}