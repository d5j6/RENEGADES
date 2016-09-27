﻿//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Effects
{
    public class Effect : MonoBehaviour
    {

        private float effectAlpha=1;
        public bool fadeOut = false;

        private SpriteRenderer sprite;
        private SpriteRenderer Sprite
        {
            get { return sprite ?? (sprite = GetComponent<SpriteRenderer>()); }
        }

        private const float FADE_SPEED = 0.5f;

        private void Awake()
        {
            SetLifetime(2);
        }

        private void Update()
        {
            OnUpdate();
            if (fadeOut)
            {
                effectAlpha -= Time.deltaTime * FADE_SPEED;
                SetAlpha(effectAlpha);
            }
        }

        //used for child classes to call in this update
        public virtual void OnUpdate()
        {

        }

        public virtual void SetLifetime(float time)
        {
            Invoke("Deactivate", time);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        private void SetAlpha(float alpha)
        {
            Sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, effectAlpha);
        }
    }
}
