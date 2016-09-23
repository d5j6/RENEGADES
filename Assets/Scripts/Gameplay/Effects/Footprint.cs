//App

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Effects
{
    public class Footprint : MonoBehaviour
    {

        private SpriteRenderer sprite;
        private SpriteRenderer SpriteRender
        {
            get { return sprite ?? (sprite = GetComponent<SpriteRenderer>()); }
        }

        private const float LIFETIME = 0.25f;
        private const float FADE_TIME = 1.0f;
        private const iTween.EaseType FADE_EASETYPE = iTween.EaseType.linear;

        private void OnEnable()
        {
            SpriteRender.color = new Color32(255, 255, 255, 255);
        }

        private void OnDisable()
        {

        }

        public void SetContent(Sprite sprite, bool flip,float size)
        {
            transform.localScale = new Vector3(size, size, size);
            SpriteRender.sprite = sprite;
            SpriteRender.flipX = flip;
            Invoke("FadeOut", LIFETIME);
        }

        private void FadeOut()
        {
            iTween.ValueTo(gameObject, iTween.Hash(
             "from", sprite.color,
             "to", new Color(255,255,255,0),
             "time", FADE_TIME,
             "easetype", FADE_EASETYPE,
             "oncomplete","FadeOut_OnComplete",
             "onupdate", "Fade_Update"));
        }

        private void Fade_Update(Color newValue)
        {
            
            SpriteRender.color = newValue;
        }

        private void FadeOut_OnComplete()
        {
            gameObject.SetActive(false);
        }
    }
}
