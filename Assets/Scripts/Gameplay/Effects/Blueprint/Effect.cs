//Unity
using UnityEngine;

//Game
using GameEngineering.Common;

//C#
using System.Collections;

namespace RENEGADES.Gameplay.Effects
{
    public class Effect : PooledObject
    {

        private float effectAlpha = 1;
        public bool fadeOut = false;
        private float timer;
        private float fadeOutTime;

        private SpriteRenderer sprite;
        private SpriteRenderer Sprite
        {
            get { return sprite ?? (sprite = GetComponent<SpriteRenderer>()); }
        }

        private Animator animator;
        private Animator _Animator
        {
            get { return animator ?? (animator = GetComponent<Animator>()); }
        }

        private const float FADE_SPEED = 0.5f;


        public override void Show()
        {
            base.Show();
            _Animator.Play("Play", -1, 0); //"Sadly theres no way that I know to reset the animation
        }

        public override void Remove()
        {
            base.Remove();
            SetAlpha(1);
            effectAlpha = 1;
            fadeOut = false;
            timer = 0;
        }

        private void Update()
        {
            OnUpdate();
            if (fadeOut)
            {
                effectAlpha -= Time.deltaTime * FADE_SPEED;
                SetAlpha(effectAlpha);
            }
            timer += Time.deltaTime;
            if (timer > fadeOutTime) fadeOut = true;
        }

        //used for child classes to call in this update
        public virtual void OnUpdate()
        {

        }

        public void BUILD(EffectBlueprint.Blueprint blueprint)
        {
            name = blueprint.name;
            SetLifetime(blueprint.lifeTime);
            _Animator.runtimeAnimatorController = blueprint.animator;
            fadeOutTime = blueprint.fadeOutTime;
        }

        public virtual void SetLifetime(float time)
        {
            StartCoroutine(Deactivate(time));
        }

        public IEnumerator Deactivate(float time)
        {
            yield return new WaitForSeconds(time);
            GetPooler().RemovePooledObject(this);
        }

        public void SetPosition(Vector3 pos)
        {
            transform.position = pos;
        }

        private void SetAlpha(float alpha)
        {
            Sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, effectAlpha);
        }
    }
}
