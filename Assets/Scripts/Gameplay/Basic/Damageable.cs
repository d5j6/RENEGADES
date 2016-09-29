//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Basic
{
    //Basic element that can be damaged by enemies (players and bases)
    public class Damageable : MonoBehaviour
    {

        private SpriteRenderer sprite;
        private SpriteRenderer Sprite
        {
            get { return sprite ?? (sprite = GetComponent<SpriteRenderer>()); }
        }


        public float HEALTH;

        private void Awake()
        {
            Init();
            SetHealth(0);
            SetLayer();
        }

        public virtual void Init() {  }

        public virtual void SetLayer()
        {
            gameObject.layer = 10; //Damageable layer
        }

        public int GetLayer()
        {
            return (1 << gameObject.layer);
        }

        public virtual void SetHealth(float h)
        {
            HEALTH = h;
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public Bounds GetBounds()
        {
            return Sprite.bounds;
        }
    }
}
