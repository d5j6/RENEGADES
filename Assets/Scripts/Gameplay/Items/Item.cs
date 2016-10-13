//Game
using RENEGADES.Gameplay.Players;
using RENEGADES.Common.Gameplay;

//Unity
using UnityEngine;



namespace RENEGADES.Gameplay.Items
{
    public class Item : MonoBehaviour
    {
        private Player player;

        private float FindPlayerTimer;
        private const float SEARCH = 0.2f;

        private const float RANGE = 5;

        private const float MOVESPEED = 2.0f;

        private void Update()
        {
            OnUpdate();
            FindPlayerTimer += Time.deltaTime;
            if (FindPlayerTimer > SEARCH)
            {
                FindPlayerTimer = 0;
                FindPlayerInRange();
            }
           // GravitateTowards();
        }

        public virtual void OnUpdate() { }

        private void GravitateTowards()
        {
            if (player == null) return;
            transform.position = Vector3.MoveTowards(transform.position, player.GetPosition(), MOVESPEED * Time.deltaTime);
        }

        private void FindPlayerInRange()
        {
            player = FindClosest.Find<Player>(transform,RANGE);
        }

        public virtual void Remove()
        {

        }

    }
}
