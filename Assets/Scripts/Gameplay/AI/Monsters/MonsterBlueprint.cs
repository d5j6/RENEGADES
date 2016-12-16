//Game
using RENEGADES.Audio;

//Unity
using UnityEngine;

//C#
using System.Collections.Generic;

namespace RENEGADES.Gameplay.AI.Monsters
{
    [CreateAssetMenu]
    public class MonsterBlueprint : ScriptableObject
    {
        public enum EnemyType { Ghoul,Soldier }
        public enum DIFFICULTY { Easy,Medium,Hard,Nightmare}

        [System.Serializable]
        public struct EnemyBlueprint
        {
            public string name;
            public EnemyType type;
            public DIFFICULTY difficulty;
            public MonsterAI monster;
            public float speed;
            public float health;
            public float attackRange;
            public float attackSpeed;
            public float damage;
            public Sounds.Sound deathSound;
        }

        public List<EnemyBlueprint> Enemies;



    }
}
