//Unity
using UnityEngine;

namespace GameEngineering.Common
{
    public class PooledObject : MonoBehaviour
    {
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Remove()
        {
            gameObject.SetActive(false);
        }
    }
}
