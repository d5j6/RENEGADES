//Game
using RENEGADES.Managers;

//Unity
using UnityEngine;

//C#
using System.Collections;

namespace RENEGADES.Gameplay.Basic
{
    /// <summary>
    /// used to test enemies spawning in spawnbox mode
    /// </summary>
    public class Portal : MonoBehaviour
    {


        private int count = 1;
        private float time = 2;

        public void Awake()
        {
            StartCoroutine(Generate());
        }

        private IEnumerator Generate()
        {
            for(int i=0; i < count; i++)
            {
                GameManager.Instance.MonsterSpawner.CreateMonster(Generators.EnemyGenerator.EnemyType.Ghoul, transform.position);
                yield return new WaitForSeconds(time);
            }
            Again();

        }

        private void Again()
        {
            count++;
            time -= 0.1f;
            StartCoroutine(Generate());
        }

    }
}
