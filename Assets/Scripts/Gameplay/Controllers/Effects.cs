//App
using RENEGADES.Gameplay.Effects;

//Unity
using UnityEngine;

//C#
using System.Collections.Generic;

namespace RENEGADES.Gameplay.Controllers
{
    public class Effects : Spawner
    {
        public enum EffectType
        {
            BloodSplat,
            BloodExplosion
        }

        [System.Serializable]
        public class EffectToSpawn
        {
            public EffectType type;
            public Effect effect;
        }

        [Header("List of All Effects")]
        [Tooltip("All Effects that can be spawned in the game")]
        public List<EffectToSpawn> EffectsToSpawn;

        //Called on start
        public override void Init()
        {
            
        }

        public override void Spawn<T>(T obj, Vector3 pos)
        {
            base.Spawn<T>(obj, pos);
        }

        public void Spawn(EffectType t,Vector3 pos)
        {
            int index = EffectsToSpawn.FindIndex(x => x.type == t);
            Spawn(EffectsToSpawn[index].effect, pos);
        }

    }
}
