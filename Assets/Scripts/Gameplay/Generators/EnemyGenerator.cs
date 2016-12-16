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
        //enemy blueprint scriptable object
        public MonsterBlueprint blueprint;

        /// <summary>
        /// lookup
        /// </summary>
        private Dictionary<MonsterBlueprint.EnemyType, MonsterBlueprint.EnemyBlueprint> lookup;

        //init
        public override void Init() { CreateLookup(); }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q)) CreateMonster(MonsterBlueprint.EnemyType.Soldier);
            if (Input.GetKeyDown(KeyCode.R)) CreateMonster(MonsterBlueprint.EnemyType.Ghoul);
        }

        /// <summary>
        /// create lookup
        /// </summary>
        private void CreateLookup()
        {
            if (lookup != null) return;
            lookup = new Dictionary<MonsterBlueprint.EnemyType, MonsterBlueprint.EnemyBlueprint>();
            foreach (MonsterBlueprint.EnemyBlueprint monster in blueprint.Enemies)
            {
                lookup.Add(monster.type, monster);
            }
        }

        /// <summary>
        /// creates monster at a specific position
        /// </summary>
        /// <param name="type"></param>
        /// <param name="pos"></param>
        public void CreateMonster(MonsterBlueprint.EnemyType type, Vector3 pos)
        {
            if (lookup == null) CreateLookup();
            MonsterAI ai = Spawn(lookup[type].monster, pos) as MonsterAI;
            ai.BuildMonster(lookup[type]);
        }

        /// <summary>
        /// Creates monster to the right of the main camera
        /// </summary>
        /// <param name="type"></param>
        public void CreateMonster(MonsterBlueprint.EnemyType type)
        {
            if (lookup == null) CreateLookup();
            MonsterAI ai = Spawn(lookup[type].monster, GetPosition()) as MonsterAI;
            ai.BuildMonster(lookup[type]);
        }

        /// <summary>
        /// Returns position to the right of the main camera
        /// </summary>
        /// <returns></returns>
        private Vector3 GetPosition()
        {
            float x = 1.0f;
            float y = Random.Range(0.0f, 1.0f);
            float z = 10;
            return Camera.main.ViewportToWorldPoint(new Vector3(x, y, z));
        }

        /// <summary>
        /// OnDestroy
        /// </summary>
        private void OnDestroy()
        {
            lookup.Clear();
            lookup = null;
        }

    }
}
