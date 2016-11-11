//Unity
using UnityEngine;

//Game
using RENEGADES.Gameplay.Players;
using GameEngineering.Common;

namespace RENEGADES.Gameplay.Weapons
{

    public class BombPlanter : GenericPooler
    {
        private Player player;
        private Player _Player
        {
            get { return player ?? (player = GetComponentInParent<Player>()); }
        }
        public override void Init()
        {
            base.Init();
            SetIdealTransform(GameObject.Find("Pooled Object Container").transform);
        }

        private const int CRYSTAL_COST = 20;

        private float bombCooldown = 0.5f;
        private float bombTimer = 0;
        public bool cooling = false;

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (cooling)
            {
                bombTimer += Time.deltaTime;
                if (bombTimer > bombCooldown)
                {
                    cooling = false;
                    bombTimer = 0;
                }
            }
        }

        public void PlantBomb()
        {
            if (_Player.GetCrystals() < CRYSTAL_COST) return;
            if (cooling) return;
            cooling = true; //we have succesfully planted a bomb
            Vector3 pos = new Vector3(transform.position.x, transform.position.y -0.75f, 0);
            GetPooledObject(pos);
            _Player.UpdateCrystals(-CRYSTAL_COST);
        }

        public void RemoveBomb(Bomb b)
        {
            RemovePooledObject(b);
        }
    }
}
