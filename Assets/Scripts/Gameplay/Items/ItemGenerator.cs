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

        private const float SPAWN_RANGE = 0.5f;

        public override void Init() { }

        private void Update()
        {
            if (Input.GetKey(KeyCode.X)) Debug.Log(GetSpawnCount());
        }

        public void SpawnCluster(AI.DIFFICULTY difficulty,Vector3 origin)
        {
            int itemCount = GetSpawnCount();
            for (int i = 0; i < itemCount; i++)
            {
                int itemIndex = 0;
                Spawn(itemBlueprint.ItemTypes[itemIndex].Prefab, (DeterminePosition(i, itemCount, origin)));
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
            float x = SPAWN_RANGE * (Mathf.Cos(2 * Mathf.PI / Count * index + g)+origin.x);
            float y = SPAWN_RANGE * (Mathf.Sin(2 * Mathf.PI / Count * index + g)+origin.y);
            return new Vector3(x, y, 0);

        }

        private int GetSpawnCount()
        {
            return Mathf.Clamp(UnityEngine.Random.Range(-6, 4), 0, 3) + 1;
        }

    }
}
