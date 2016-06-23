//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Background
{

    public class BackgroundStretch : MonoBehaviour
    {
        private SpriteRenderer sr;
        private SpriteRenderer SR
        {
            get { return sr ?? (sr = GetComponent<SpriteRenderer>()); }
        }

        private float worldScreenHeight;
        private float worldScreenWidth;

        private void Awake()
        {
            GetDimensions();
            ResizeBackground();
        }

        private void GetDimensions()
        {
            worldScreenHeight = GameObject.FindGameObjectWithTag("BackgroundCAM").GetComponent<Camera>().orthographicSize * 2;
            worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
        }

        private void ResizeBackground()
        {
            transform.localScale = new Vector3(
                worldScreenWidth / SR.sprite.bounds.size.x,
                worldScreenHeight / SR.sprite.bounds.size.y, 1);
        }
        
    }
}
