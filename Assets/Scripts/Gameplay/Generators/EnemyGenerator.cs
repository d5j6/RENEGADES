//App
using RENEGADES.Gameplay.AI.Monsters;

//C#
using System.Collections.Generic;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Generators
{
    public class EnemyGenerator : Spawner
    {
        public MonsterBlueprint blueprint;

        private Dictionary<MonsterBlueprint.EnemyType, MonsterBlueprint.EnemyBlueprint> lookup;

        public override void Init() { CreateLookup(); }

        private void CreateLookup()
        {
            if (lookup != null) return;
            lookup = new Dictionary<MonsterBlueprint.EnemyType, MonsterBlueprint.EnemyBlueprint>();
            foreach (MonsterBlueprint.EnemyBlueprint monster in blueprint.Enemies)
            {
                lookup.Add(monster.type, monster);
            }
        }

        public void CreateMonster(MonsterBlueprint.EnemyType type, Vector3 pos)
        {
            if (lookup == null) CreateLookup();
            MonsterAI ai = Spawn(lookup[type].monster, pos) as MonsterAI;
            ai.BuildMonster(lookup[type]);
        }

        private void OnDestroy()
        {
            lookup.Clear();
            lookup = null;
        }

    }
}
