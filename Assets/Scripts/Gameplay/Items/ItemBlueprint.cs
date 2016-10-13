//Unity
using UnityEngine;

//C#
using System;
using System.Collections.Generic;

namespace RENEGADES.Gameplay.Items
{
    [CreateAssetMenu]
    public class ItemBlueprint : ScriptableObject
    {
        [Serializable]
        public struct Blueprint
        {
            public string name;
            public ItemGenerator.RARITY rarity;
            public ItemGenerator.TYPE type;
            public Item Prefab;   
        }

        public List<Blueprint> ItemTypes;

    }
}
