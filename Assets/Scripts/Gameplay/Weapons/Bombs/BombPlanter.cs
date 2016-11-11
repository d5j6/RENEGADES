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

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public void PlantBomb()
        {
            if (_Player.GetCrystals() < CRYSTAL_COST) return;
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
