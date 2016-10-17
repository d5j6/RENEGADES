//Game
using RENEGADES.Gameplay.Players;
using RENEGADES.Common.Gameplay;
using RENEGADES.Common;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Items
{
    public class Item : MonoBehaviour
    {
        private SpriteRenderer sprite;
        private SpriteRenderer Sprite
        {
            get { return sprite ?? (sprite = GetComponent<SpriteRenderer>()); }
        }

        private Player player;

        private float FindPlayerTimer;
        private float lifeTimeTimer;

        //consts
        private const float SEARCH = 0.2f;
        private const float RANGE = 5;
        private const float MOVESPEED = 2.0f;
        private const float LIFETIME = 8.0f;

        private Lerper lerper = new Lerper(0.25f);

        private float shit;

        private void Update()
        {
            OnUpdate();
            FindPlayerTimer += Time.deltaTime;
            if (FindPlayerTimer > SEARCH)
            {
                FindPlayerTimer = 0;
                FindPlayerInRange();
            }
            GravitateTowards();
            LifeTime();
        }

        public virtual void OnUpdate() { }

        private void LifeTime()
        {
            lifeTimeTimer += Time.deltaTime;

            
            if (lifeTimeTimer > LIFETIME-2)
            {
                Sprite.color = lerper.Morph(true, Sprite.color, new Color(0,0,0,0));
            }
            if(lifeTimeTimer > LIFETIME)
            {
                Remove();
            }
        }

        private void GravitateTowards()
        {
            if (player == null) return;
            transform.position = Vector3.MoveTowards(transform.position, player.GetPosition(), MOVESPEED * Time.deltaTime);
        }

        private void FindPlayerInRange()
        {
            player = FindClosest.Find<Player>(transform,RANGE);
        }

        public virtual void OnTriggerEnter2D()
        {
            Remove();
        }

        public Player GetPlayer()
        {
            FindPlayerInRange();
            return player;
        }

        public virtual void Remove()
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            lerper = null;
        }

    }
}
