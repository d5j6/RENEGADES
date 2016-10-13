//Game
using RENEGADES.Gameplay.Controllers;

//Unity
using UnityEngine;

//C#
using System;
using System.Collections.Generic;

namespace RENEGADES.Gameplay.Items
{
    public class ItemGenerator : Spawner
    {
        public enum RARITY { Common, Uncommon, Rare, Legendary, Epic }
        public enum TYPE { Coin, HealthPotion }

        public ItemBlueprint itemBlueprint;

        private const float SPAWN_RANGE = 1.1f;

        public override void Init() { }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X)) SpawnCluster(FindObjectOfType<Players.Player>().GetPosition());
        }

        public void SpawnCluster(Vector3 origin)
        {
            CreateItem(itemBlueprint.ItemTypes[0].Prefab, 3,origin);
        }

        public void CreateItem(Item item, int Count, Vector3 origin)
        {
            for (int i = 0; i < Count; i++)
            {
                Spawn(item, (DeterminePosition(i, Count, origin)));
            }
        }

        /// <summary>
        /// This will allow the items to split in an equal number of directions as they split
        /// </summary>
        /// <param name="index"></param>
        /// <param name="Count"></param>
        /// <param name="origin"></param>
        /// <returns></returns>
        private Vector3 DeterminePosition(int index, int Count, Vector3 origin)
        {
            float g = 0.5f * Mathf.PI / Count;
            float x = Mathf.Cos(2 * Mathf.PI / Count * index + g)+origin.x;
            float y = Mathf.Sin(2 * Mathf.PI / Count * index + g)+origin.y;
            return new Vector3(x, y, 0);

        }

    }
}
