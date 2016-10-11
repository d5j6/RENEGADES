﻿//App
using RENEGADES.Constants;
using RENEGADES.Gameplay.Players;
using RENEGADES.Common;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Weapons
{
    public class RangedAttack : MonoBehaviour
    {

        public Projectile element;

        private const float COOLDOWN = 0.25f;
        public float timer;

        private bool coolingDown;

        private AnimationTriggers.PlayerAnimation currentTrigger;

        private ObjectPooler pooler;
        private ObjectPooler Pooler
        {
            get { return pooler ?? (pooler = GetComponent<ObjectPooler>()); }
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
            Plasma spawn = Pooler.GetPooledObject().GetComponent<Plasma>();
            spawn.Init(transform.position);
            spawn.SetMoveSpeed(100);
            spawn.SetEulerAngles(currentTrigger);
            spawn.SetDamage(5);
        }
       
    }
}
