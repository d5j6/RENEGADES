//App
using RENEGADES.Gameplay.Players;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Effects
{
    public class Footprints : MonoBehaviour
    {
        [Header("Sprite for Footprint")]
        public Sprite footPrintSprite;

        [Header("Footprint GameObject")]
        public Footprint footPrintPrefab;

        private PlayerMovement movement;
        private PlayerMovement Movement
        {
            get { return movement ?? (movement = GetComponentInParent<PlayerMovement>()); }
        }

        private const float FOOTPRINT_TIMER = 0.25f;
        private const float DISTANCE_THRESHOLD = 0.25f;

        private Vector3 lastPosition;

        private bool flipPrint;

        private void Awake()
        {
            InvokeRepeating("CheckFootPrint_OnUpdate", 0,FOOTPRINT_TIMER);
            lastPosition = Movement.transform.position;
        }

        private void CheckFootPrint_OnUpdate()
        {
            float distanceTraveled = Vector3.Distance(lastPosition, Movement.transform.position);
            Debug.Log(distanceTraveled);
            if (distanceTraveled > DISTANCE_THRESHOLD)
            {
                Spawn();
            }
            lastPosition = Movement.transform.position;
        }

        private void Spawn()
        {
            Footprint print = Instantiate(footPrintPrefab);
            print.transform.SetParent(GameObject.Find("Edge").transform, false);
            print.transform.position = transform.position;
            print.SetContent(footPrintSprite,flipPrint);
            flipPrint = !flipPrint;
        }
    }
}
