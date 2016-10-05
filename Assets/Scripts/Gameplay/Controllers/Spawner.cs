//Unity
using UnityEngine;

//C#


namespace RENEGADES.Gameplay.Controllers
{
    public abstract class Spawner : MonoBehaviour
    {

        private Transform world;
        public Transform WORLD
        {
            get { return world ?? (world = FindObjectOfType<Background.WORLD>().transform); }
        }

        private Transform hud;
        private Transform HUD
        {
            get { return hud ?? (hud = FindObjectOfType<Canvas>().transform); }
        }

        private void Awake()
        {
            Init();
        }

        //abstract class for initilization
        public abstract void Init();

        /// <summary>
        /// basic spawn no return
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="pos"></param>
        public virtual void Spawn<T>(T obj,Vector3 pos) where T :Component
        {
            T g = Instantiate(obj,pos,Quaternion.identity,WORLD) as T;
        }

        /// <summary>
        /// Returns a spawned object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual T Spawn<T>(T obj) where T : Component
        {
            T g = Instantiate(obj, Vector3.zero, Quaternion.identity, WORLD) as T;
            return g;
        }

        /// <summary>
        /// Spawn UI no return
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="pos"></param>
        public virtual void SpawnUI<T>(T obj) where T : Component
        {
            T g = Instantiate(obj, HUD) as T;
        }

    }
}
