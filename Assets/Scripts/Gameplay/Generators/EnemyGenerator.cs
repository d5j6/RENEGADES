//App
using RENEGADES.Gameplay.AI;

//C#
using System.Collections.Generic;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Generators
{
    public class EnemyGenerator : Spawner
    {
        public enum EnemyType { Ghoul}

        [System.Serializable]
        public struct EnemyBlueprint
        {
            public EnemyType type;
            public MonsterAI monster;
        }

        public List<EnemyBlueprint> Enemies;

        public override void Init(){ }

        public void CreateMonster(EnemyType type,Vector3 pos)
        {
            int index = Enemies.FindIndex(x => x.type == type);
            Spawn(Enemies[index].monster, pos);
        }

    }
}
