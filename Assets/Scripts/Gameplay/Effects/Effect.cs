//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Effects
{
    public class Effect : MonoBehaviour
    {
        private void Awake()
        {
            SetLifetime(2);
        }

        public virtual void SetLifetime(float time)
        {
            Invoke("Deactivate", time);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
