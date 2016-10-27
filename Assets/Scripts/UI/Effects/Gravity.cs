//Unity
using UnityEngine;

namespace RENEGADES.UI.Effects
{
    public class Gravity : MonoBehaviour
    {
        [Header("Float Range Factor")]
        [Range(0,2)]
        public float floating = 0.25f;

        private RectTransform rect;
        private RectTransform Rect
        {
            get { return rect ?? (rect = GetComponent<RectTransform>()); }
        }

        private float fx, fy;

        private void Start()
        {
            if (name == "Character Select Button") UnityEngine.UI.Selectable.allSelectables[0].Select();
            fx = Random.Range(0.4f, 0.7f);
            fy = Random.Range(0.4f, 0.7f);
        }

        // Update is called once per frame
        void Update()
        {
            float xx, yy;
            xx = 0.5f + floating * 0.1f * Mathf.Cos((Time.time + fx * 100) * fx);
            yy = 0.5f + floating * 0.1f * Mathf.Sin((Time.time + fy * 100) * fy);
            Rect.pivot = new Vector2(xx, yy);

        }
    }
}
