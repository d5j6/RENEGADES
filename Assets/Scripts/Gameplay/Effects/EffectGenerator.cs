//App
using GameEngineering.Common;

//Unity
using UnityEngine;

//C#
using System.Collections.Generic;

namespace RENEGADES.Gameplay.Effects
{
    /// <summary>
    /// Using a Generic Pooler for performance on effects
    /// Animator,etc gets reset each time an object is created 
    /// This uses a Scriptable object lookup
    /// </summary>
    public class EffectGenerator : GenericPooler
    {
        [Header("Default Materials")]
        public Material defaultParticleMAT;

        [Header("Effect Scriptable Object")]
        public EffectBlueprint blueprint;

        private Dictionary<EffectBlueprint.EffectType, EffectBlueprint.Blueprint> lookup;

        //Called on start
        public override void Init()
        {
            base.Init();
            CreateLookUp();
        }

        private void CreateLookUp()
        {
            lookup = new Dictionary<EffectBlueprint.EffectType, EffectBlueprint.Blueprint>();
            foreach (EffectBlueprint.Blueprint b in blueprint.blueprints)
            {
                if (lookup.ContainsKey(b.type)) Debug.LogError("Effect Blueprint has multiple types, Please fix!");
                else { lookup.Add(b.type, b); }
            }
        }

        public void CreateEffect(EffectBlueprint.EffectType type, Vector3 pos)
        {
            Effect effect = GetPooledObject(pos) as Effect;
            effect.BUILD(lookup[type]);
        }

        private void OnDestroy()
        {
            if (lookup != null) lookup.Clear();
            lookup = null;
        }

    }
}
