//Unity
using UnityEngine;

//C#
using System.Collections.Generic;

//App
using RENEGADES.Gameplay.Weapons;

namespace RENEGADES.Gameplay.AI.Turrets
{
    [CreateAssetMenu]
    public class TurretType : ScriptableObject
    {
        public enum TurretKey
        {
            Basic,
            Lancer,
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
            public Projectile projectilePrefab;
            public Turret turretPrefab;
            public float projectileSpeed;
            public float projectileDamage;
            public float price;
        }

        public List<TurretBlueprint> TurretTypes;

    }
}
