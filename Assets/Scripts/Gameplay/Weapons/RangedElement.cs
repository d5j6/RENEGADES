//App
using RENEGADES.Constants;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Weapons
{
    public class RangedElement : MonoBehaviour
    {
        private Vector3 moveDirection;

        public void SetMoveDirection(Vector3 v)
        {
            moveDirection = v;
            Invoke("Destroy", 2.0f);
        }

        public void Update()
        {
            transform.position += moveDirection * Time.deltaTime*12;
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }
       
    }
}
