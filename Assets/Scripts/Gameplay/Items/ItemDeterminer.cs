﻿//C#
using System;
using System.Collections.Generic;

//Game
using RENEGADES.Gameplay.AI.Monsters;

namespace RENEGADES.Gameplay.Items
{
    /// <summary>
    /// What item will spawn based on type
    /// </summary>
    public class ItemDeterminer
    {

        public enum RARITY { Common, Uncommon, Rare, Legendary, Exotic }
        public enum TYPE { Crystal, HealthPotion,RareCrystal,UltraCrystal,SpeedPotion }

        public class ItemData
        {
            public RARITY rarity;
            public int weight;
            public float cumulativeValue;
            public ItemData(RARITY rarity, int weight) { this.rarity = rarity; this.weight = weight; }
        }

        private static Random R = new Random();

        private static bool CumulativesCalculated = false;

        /// <summary>
        /// Determiner using Weighted Randomization to pick an item Rarity based on Monster Difficulty once a monster has died
        /// </summary>
        private static Dictionary<MonsterBlueprint.DIFFICULTY, List<ItemData>> Determiner = new Dictionary<MonsterBlueprint.DIFFICULTY, List<ItemData>>()
        {
            {MonsterBlueprint.DIFFICULTY.Easy,
            new List<ItemData>{
                { new ItemData(RARITY.Common, 80) },
                { new ItemData(RARITY.Uncommon, 20) },
                { new ItemData(RARITY.Rare, 0) },
                { new ItemData(RARITY.Exotic, 0) },
                { new ItemData(RARITY.Legendary, 0) }} },
            //-----------------------------------------------//
            {MonsterBlueprint.DIFFICULTY.Medium,
             new List<ItemData>{
                { new ItemData(RARITY.Common, 50) },
                { new ItemData(RARITY.Uncommon, 40) },
                { new ItemData(RARITY.Rare, 10) },
                { new ItemData(RARITY.Exotic, 0) },
                { new ItemData(RARITY.Legendary, 0) }} },
            //-----------------------------------------------//
            {MonsterBlueprint.DIFFICULTY.Hard,
            new List<ItemData>{
                { new ItemData(RARITY.Common, 20) },
                { new ItemData(RARITY.Uncommon, 50) },
                { new ItemData(RARITY.Rare, 20) },
                { new ItemData(RARITY.Exotic, 10) },
                { new ItemData(RARITY.Legendary, 0) }} },
            //-----------------------------------------------//
            {MonsterBlueprint.DIFFICULTY.Nightmare,
            new List<ItemData>{
                { new ItemData(RARITY.Common, 0) },
                { new ItemData(RARITY.Uncommon, 0) },
                { new ItemData(RARITY.Rare, 50) },
                { new ItemData(RARITY.Exotic, 35) },
                { new ItemData(RARITY.Legendary, 15) }} },
            //-----------------------------------------------//
        };

        private static T Choose<T>(List<T> list) where T : ItemData
        {
            if (list == null || list.Count == 0) return default(T);
            if (!CumulativesCalculated) SetCumlatives();

            double randomValue = R.Next(0, 100) / 100.0f;

            for(int i=0; i<= list.Count; i++)
            {
                if (list[i].cumulativeValue >randomValue) return list[i];
            }

            return default(T);
        }

        public static void SetCumlatives()
        {
            CumulativesCalculated = true;
            foreach (var deter in Determiner)
            {
                float sum = 0;
                foreach (ItemData data in deter.Value)
                {
                    if (data.weight > 0)
                    {
                        data.cumulativeValue = (data.weight / 100.0f) + sum;
                        sum += data.cumulativeValue;
                    }
                    else
                    {
                        data.cumulativeValue = 0;
                    }
                }
            }
        }

        public static RARITY GetItem(MonsterBlueprint.DIFFICULTY difficulty)
        {
            return Choose(Determiner[difficulty]).rarity;
        }


    }
}
