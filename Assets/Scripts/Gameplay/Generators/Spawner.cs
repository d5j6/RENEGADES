//Unity
using UnityEngine;
using RENEGADES.UI.Managers;

//C#


namespace RENEGADES.Gameplay.Generators
{
    public abstract class Spawner : MonoBehaviour
    {
        public Transform idealTransform;

        private Transform world;
        public Transform WORLD
        {
            get { return world ?? (world = FindObjectOfType<Background.WORLD>().transform); }
        }

        private Transform hud;
        private Transform HUD
        {
            get { return hud ?? (hud = FindObjectOfType<MainCanvas>().transform); }
        }

        private void Awake()
        {
            Init();
            if (idealTransform == null) idealTransform = WORLD;
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
            Instantiate(obj,pos,Quaternion.identity, idealTransform);
        }

        /// <summary>
        /// Returns a spawned object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual T Spawn<T>(T obj) where T : Component
        {
            T g = Instantiate(obj, Vector3.zero, Quaternion.identity, idealTransform) as T;
            return g;
        }

        /// <summary>
        /// Spawn UI no return
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="pos"></param>
        public virtual T SpawnUI<T>(T obj) where T : Component
        {
            T ui = Instantiate(obj, HUD,false) as T;
            return ui;
        }

    }
}
