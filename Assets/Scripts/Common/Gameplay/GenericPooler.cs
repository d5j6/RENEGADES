//Unity
using UnityEngine;

//C# & .NET
using System.Collections.Generic;

namespace RENEGADES.Common.Gameplay
{
    /// <summary>
    /// Generic Object Pooler to greatly improve performance and efficiency
    /// </summary>
    public class GenericPooler : MonoBehaviour
    {
        [Header("Parent Transform")]
        public Transform parent;

        private List<GameObject> pooledObjects;

        private void Awake()
        {
            if (parent == null) parent = GameObject.FindGameObjectWithTag("PooledObjectContainer").transform;
        }

        public T GetPooledObject<T>(T Prefab) where T : Component
        {
            if (pooledObjects == null) pooledObjects = new List<GameObject>();

            //pooled object is found
            for (int i = 0; i < pooledObjects.Count; i++)
            {
                if (!pooledObjects[i].activeInHierarchy)
                {
                    pooledObjects[i].SetActive(true);
                    return pooledObjects[i].GetComponent<T>();
                }
            }

            //not enough objects in list so spawn one
            return Spawn(Prefab);
        }

        public T Spawn<T>(T obj) where T : Component
        {
            T spawn = Instantiate(obj, parent) as T;
            pooledObjects.Add(spawn.gameObject);
            spawn.gameObject.SetActive(true);
            return spawn;
        }

    }
}