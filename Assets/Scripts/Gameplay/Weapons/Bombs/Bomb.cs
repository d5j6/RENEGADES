//Unity
using UnityEngine;

//Game
using TMPro;
using RENEGADES.Gameplay.Basic;
using RENEGADES.Common.Gameplay;
using RENEGADES.Managers;
using GameEngineering.Common;

//C#
using System.Collections.Generic;

namespace RENEGADES.Gameplay.Weapons
{

    public class Bomb : PooledObject
    {
        private const float fuseTime = 3.0f;
        private float timer;
        private float textAnimationTimer;

        private BombPlanter planter;
        private BombPlanter Planter
        {
            get { return planter ?? (planter = FindObjectOfType<BombPlanter>()); }
        }

        private TextMeshPro txt;
        private TextMeshPro Txt
        {
            get { return txt ?? (txt = GetComponentInChildren<TextMeshPro>()); }
        }

        private const float MAX_DAMAGE = 15;
        private const float DISTANCE = 2f;

        private void OnEnable()
        {
            timer = 0;
            textAnimationTimer = 1;
        }

        private void Update()
        {
            timer += Time.deltaTime;
            textAnimationTimer += Time.deltaTime;
            if(textAnimationTimer > 1)
            {
                AnimateText();
                textAnimationTimer = 0;
            }
            if(timer > fuseTime)
            {
                Explode();
            }
        }

        private void Explode()
        {
            GameManager.Instance.EffectSpawner.CreateEffect(Effects.EffectGenerator.EffectType.PlasmaExplosion, transform.position);
            DAMAGE();
            Destroy();
        }

        private void DAMAGE()
        {
            Dictionary<Damageable, float> elementsAround = FindClosest.Find_Group<Damageable>(transform, DISTANCE);
            foreach(var element in elementsAround)
            {
                Debug.Log(element.Key.name);
                //damage based on distance
                element.Key.ChangeHealth(-Mathf.Clamp(15-(element.Value*3),1,MAX_DAMAGE));
            }

        }

        private void AnimateText()
        {
            Txt.text = ((int)(4 - timer)).ToString();
            iTween.PunchScale(Txt.gameObject, new Vector3(1.1f, 1.1f, 1.1f), 0.5f);
        }

        private void Destroy()
        {
            if (Planter == null)
            {
                Destroy(gameObject);
                return;
            }
            Planter.RemoveBomb(this);
        }
    }
}
