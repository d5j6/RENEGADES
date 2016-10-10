//Unity
using UnityEngine;

//C#
using System.Collections.Generic;

namespace RENEGADES.Gameplay.AI
{
    [CreateAssetMenu]
    public class TurretType : ScriptableObject
    {
        public enum TurretKey
        {
            Basic,
            Laser,
            Rocket
        }

        [System.Serializable]
        public struct TurretBlueprint
        {
            public string name;
            public TurretKey key;
            public Sprite sprite;
            public float fireRate;
            public float health;
            public float range;
            public float turnSpeed;
        }

        public List<TurretBlueprint> TurretTypes;

    }
}
