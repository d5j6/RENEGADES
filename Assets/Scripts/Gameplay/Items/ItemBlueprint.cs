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
            public ItemDeterminer.TYPE key;
            public Item Prefab;
            public ItemDeterminer.RARITY rarity;
        }

        public List<Blueprint> ItemTypes;

    }
}
