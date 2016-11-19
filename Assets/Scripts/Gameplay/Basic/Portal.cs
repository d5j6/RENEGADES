//Game
using RENEGADES.Managers;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Basic
{
    /// <summary>
    /// used to test enemies spawning in spawnbox mode
    /// </summary>
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
            GameManager.Instance.MonsterSpawner.CreateMonster(Generators.EnemyGenerator.EnemyType.Ghoul, transform.position);
        }
    }
}
