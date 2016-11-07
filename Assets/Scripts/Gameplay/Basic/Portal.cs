//Game
using RENEGADES.Managers;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Basic
{
    public class Portal : MonoBehaviour
    {
        private float rate;
        public void Awake()
        {
            rate = Random.Range(1, 3);
            InvokeRepeating("Generate", 0, rate);
        }


        private void Generate()
        {
            GameManager.Instance.MonsterSpawner.CreateMonster(Controllers.EnemyGenerator.EnemyType.Ghoul, transform.position);
            GameManager.Instance.EffectSpawner.CreateEffect(Effects.EffectGenerator.EffectType.EnemySpawn, transform.position);
        }
    }
}
