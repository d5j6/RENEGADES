//Unity
using UnityEngine;

//C#
using System.Collections.Generic;

namespace RENEGADES.Gameplay.Controllers
{
    public abstract class Spawner : MonoBehaviour
    {

        private void Awake()
        {
            Init();
        }

        public abstract void Init();

        public virtual void Spawn<T>(T obj,Vector3 pos) where T :Component
        {
            T g = Instantiate(obj) as T;
            g.transform.position = pos;
        }

    }
}
