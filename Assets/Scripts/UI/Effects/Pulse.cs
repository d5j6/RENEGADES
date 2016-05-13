//Unity
using UnityEngine;
using TMPro;

namespace RENEGADES.UI.Effects
{
    public class Pulse : MonoBehaviour
    {
        [Header("Two Values to Pulse From")]
        [Tooltip("Two Values to Ping Pong From in Code")]
        public float minValue;
        public float maxValue;

        [Header("Speed")]
        [Tooltip("The Speed of the Pulse")]
        public float pulseSpeed = 1.0f;

        [Header("Animation Ease Type")]
        [Tooltip("Easetype for the Pulse Animation")]
        public iTween.EaseType EASE_TYPE;

        private TextMeshProUGUI text;
        private TextMeshProUGUI Text
        {
            get { return text ?? (text = GetComponent<TextMeshProUGUI>()); }
        }

        private float VALUE;

        private void Start()
        {
            VALUE = minValue;
            PulseTo(VALUE);
        }

        public void PulseTo(float value)
        {  
            iTween.ValueTo(gameObject, iTween.Hash(
              "from", Text.outlineWidth, 
              "to", value, 
              "time", pulseSpeed,
              "easetype", EASE_TYPE, 
              "oncomplete","Pulse_OnComplete",
              "onupdate", "Pulse_OnUpdate")); 
        }

        private void Pulse_OnUpdate(float newValue)
        {
            Text.outlineWidth = newValue; 
        }

        private void Pulse_OnComplete()
        {
            VALUE = (VALUE == minValue) ? maxValue : minValue;
            PulseTo(VALUE);
        }

        private void OnDestroy()
        {
            text = null;
        }

    }
}
