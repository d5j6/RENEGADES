//App
using RENEGADES.Constants;
using RENEGADES.Gameplay.Players;
using RENEGADES.Common;
using GameEngineering.Common;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Weapons
{
    public class RangedAttack : GenericPooler
    {

        public Projectile element;

        private const float COOLDOWN = 0.25f;
        private float timer;

        private bool coolingDown;

        private AnimationTriggers.PlayerAnimation currentTrigger;

        public override void Init()
        {
            base.Init();
            SetIdealTransform(GameObject.Find("Pooled Object Container").transform);
        }

        private void Update()
        {
            Cooldown();
        }

        private void Cooldown()
        {
            if (!coolingDown) return;
            timer += Time.deltaTime;
            if (timer > COOLDOWN)
            {
                coolingDown = false;
                timer = 0.0f;
            }
        }

        public void FIRE(Player p)
        {
            currentTrigger = p.CurrentTrigger;
            if (coolingDown) return;
            coolingDown = true;
            Spawn();
        }

        private void Spawn()
        {
            Plasma spawn = GetPooledObject(transform.position) as Plasma;
            spawn.SetMoveSpeed(100);
            spawn.SetEulerAngles(currentTrigger);
            spawn.SetDamage(5);
        }
       
    }
}
