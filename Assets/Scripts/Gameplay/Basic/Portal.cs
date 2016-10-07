//Game
using RENEGADES.Managers;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Basic
{
    public class Portal : MonoBehaviour
    {

        public void Awake()
        {
            InvokeRepeating("Generate", 0, 2.5f);
        }


        private void Generate()
        {
            GameManager.Instance.MonsterSpawner.CreateMonster(Controllers.EnemyGenerator.EnemyType.Ghoul, transform.position);
            GameManager.Instance.EffectSpawner.CreateEffect(Controllers.Effects.EffectType.EnemySpawn, transform.position);
        }
    }
}
