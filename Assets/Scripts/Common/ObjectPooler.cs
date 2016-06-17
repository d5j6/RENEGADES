//Unity
using UnityEngine;

//C#
using System.Collections.Generic;

namespace RENEGADES.Common
{
    public class ObjectPooler : MonoBehaviour
    {
        [Header("Pooled Prefab")]
        [Tooltip("Place Your Pooled Object Here")]
        public GameObject pooledObject;

        [Header("Allocated Space")]
        [Tooltip("Amount of Objects to pool")]
        public int pooledAmount = 0;

        [Header("Allow For Growth")]
        [Tooltip("Will the list grow if need be?")]
        public bool willGrow = true;

        private List<GameObject> pooledObjects;

        // Use this for initialization
        private void Awake()
        {
            Generate();
        }

        public void Generate()
        {
            pooledObjects = new List<GameObject>();
            for (int i = 0; i < pooledAmount; i++)
            {
                GameObject obj = Instantiate(pooledObject);
                obj.transform.SetParent(GameObject.FindGameObjectWithTag("PooledObjectContainer").transform, false);
                obj.transform.SetSiblingIndex(0);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }

        public void Deactivate()
        {
            if (pooledObjects == null) return;
            pooledObjects.ForEach(x => x.gameObject.SetActive(false));
        }

        public GameObject GetPooledObject()
        {
            if (pooledObjects == null) Generate();
            for(int i=0; i < pooledObjects.Count; i++)
            {
                if(!pooledObjects[i].activeInHierarchy)
                {
                    pooledObjects[i].SetActive(true);
                    return pooledObjects[i];
                }
            }

            if(willGrow)
            {
                GameObject obj = Instantiate(pooledObject);
                obj.transform.SetParent(GameObject.FindGameObjectWithTag("PooledObjectContainer").transform, false);
                obj.transform.SetSiblingIndex(0);
                obj.SetActive(true);
                pooledObjects.Add(obj);
                return obj;
            }

            Debug.LogError("No Object Found");
            return null;
        }

        private void OnDestroy()
        {
            if(pooledObjects != null)
            {
                pooledObjects.Clear();
                pooledObjects = null;
            }
        }
    }
}
