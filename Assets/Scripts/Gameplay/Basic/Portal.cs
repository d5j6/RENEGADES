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
            InvokeRepeating("Generate", 0, 2f);
        }


        private void Generate()
        {
            GameManager.Instance.MonsterSpawner.CreateMonster(Controllers.EnemyGenerator.EnemyType.Ghoul, transform.position);
            GameManager.Instance.EffectSpawner.CreateEffect(Effects.EffectGenerator.EffectType.EnemySpawn, transform.position);
        }
    }
}
