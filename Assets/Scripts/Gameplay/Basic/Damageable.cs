//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Basic
{
    //Basic element that can be damaged by enemies (players and bases)
    public class Damageable : MonoBehaviour
    {

        public float HEALTH;

        private void Awake()
        {
            Init();
            SetHealth(0);
        }

        public virtual void Init() {  }

        public virtual void SetHealth(float h)
        {
            HEALTH = h;
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }
    }
}
