//App
using RENEGADES.Gameplay.Controllers;

//Unity
using UnityEngine;

//C#
using System.Collections.Generic;

namespace RENEGADES.Gameplay.Effects
{
    public class EffectGenerator : Spawner
    {
        public enum EffectType
        {
            BloodSplat,
            BloodExplosion,
            FireExplosion,
            Spawn,
            EnemySpawn,
            PlasmaExplosion
        }

        [System.Serializable]
        public class EffectToSpawn
        {
            public string name;
            public EffectType type;
            public Effect effect;
        }

        [Header("List of All Effects")]
        [Tooltip("All Effects that can be spawned in the game")]
        public List<EffectToSpawn> EffectsToSpawn;

        [Header("Default Materials")]
        public Material defaultParticleMAT;

        //Called on start
        public override void Init()
        {
            
        }

        public void CreateEffect(EffectType t,Vector3 pos)
        {
            int index = EffectsToSpawn.FindIndex(x => x.type == t);
            Spawn(EffectsToSpawn[index].effect, pos);
        }

    }
}
