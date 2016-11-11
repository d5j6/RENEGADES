//Unity
using UnityEngine;

//C#
using System.Collections.Generic;

[CreateAssetMenu]
public class EffectBlueprint : ScriptableObject
{

    public enum EffectType
    {
        BloodSplat,
        BloodExplosion,
        FireExplosion,
        Spawn,
        PlasmaExplosion,
        Build
    }

    [System.Serializable]
    public struct Blueprint
    {
        public string name;
        public EffectType type;
        public RuntimeAnimatorController animator;
        public float lifeTime;
        public float fadeOutTime;
    }

    public List<Blueprint> blueprints;

}
