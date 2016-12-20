//Game
using RENEGADES.Gameplay.Generators;
using RENEGADES.Gameplay.AI.Monsters;

//Unity
using UnityEngine;

//C#
using System.Linq;
using System.Collections.Generic;

namespace RENEGADES.Gameplay.Items
{
    public class ItemGenerator : Spawner
    {
        public ItemBlueprint itemBlueprint;

        private const float SPAWN_RANGE = .33f;

        public override void Init() { CreatePoolers(); }

        /// <summary>
        /// Create Individual Pooler for each type of item because item functionality varies
        /// </summary>
        private void CreatePoolers()
        {
          
        }

        public void SpawnCluster(MonsterBlueprint.DIFFICULTY difficulty,Vector3 origin)
        {
            int itemCount = GetSpawnCount();
            for (int i = 0; i < itemCount; i++)
            {
                ItemDeterminer.RARITY rarity = ItemDeterminer.GetItem(difficulty);
                List<ItemBlueprint.Blueprint> rareTypes = itemBlueprint.ItemTypes.Where(x => x.rarity == rarity).ToList();

               if(rareTypes.Count > 0)Spawn(rareTypes[Random.Range(0, rareTypes.Count)].Prefab, (DeterminePosition(i, itemCount, origin)));
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
            float x = SPAWN_RANGE * (Mathf.Cos(2 * Mathf.PI / Count * index + g)) + origin.x;
            float y = SPAWN_RANGE * (Mathf.Sin(2 * Mathf.PI / Count * index + g)) + origin.y;
            //return origin;
            return new Vector3(x, y, 0);

        }

        //Get the number of items to spawn,potentialy none
        private int GetSpawnCount()
        {
            return Mathf.Clamp(Random.Range(-6, 5), 0, 5);
        }

    }
}
