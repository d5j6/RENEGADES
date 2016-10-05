//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Basic
{
    //Basic ACTOR element that can be damaged  (players,bases,AI)
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
            SetHealth(0);
            SetLayer(0); 
            Init();
        }

        private void Update()
        {
            OnUpdate();
        }

        public virtual void Init() {  }

        public virtual void OnUpdate() { }

        /// <summary>
        /// Collision Detection
        /// </summary>
        /// <param name="other"></param>
        public virtual void OnTriggerEnter2D(Collider2D other)
        {
           
        }

        public virtual void SetLayer(int layer)
        {
            gameObject.layer = layer; //Damageable layer
        }

        public int GetLayer()
        {
            return (1 << gameObject.layer);
        }

        /// <summary>
        /// Set starting health
        /// </summary>
        /// <param name="h"></param>
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

        public void UpdateHealth(float h)
        {
            HEALTH += h;
            if (HEALTH <= 0) Destroyed();
        }

        public virtual void Hurt(float h)
        {
            UpdateHealth(h);
        }

        public virtual void Destroyed()
        {

        }
    }
}
