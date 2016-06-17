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

        private const float FOOTPRINT_TIMER = 0.1f;
        private const float DISTANCE_THRESHOLD = 0.05f;

        private Vector3 lastPosition;
        private Vector3 moveDifference;

        private bool alternateFeet;
        private bool spriteFlip;

        private const float FOOTPRINT_SEPERATION = 0.1f;

        private void Awake()
        {
            InvokeRepeating("CheckFootPrint_OnUpdate", 0, FOOTPRINT_TIMER);
            lastPosition = Movement.transform.position;
        }

        private void CheckFootPrint_OnUpdate()
        {
            if (Movement.transform.position != lastPosition)
            {
                Spawn(AngleBetweenVectors(lastPosition, Movement.transform.position));
            }
            lastPosition = Movement.transform.position;
        }

        private void Spawn(float angle)
        {
            Footprint print = Instantiate(footPrintPrefab);
            print.transform.SetParent(GameObject.Find("Edge").transform, false);

            //determine our offsets
            float offSetY = 0.0f, offSetX = 0.0f;
            if (Mathf.Abs(moveDifference.x) > Mathf.Abs(moveDifference.y))
            {
                offSetY = alternateFeet ? FOOTPRINT_SEPERATION : -FOOTPRINT_SEPERATION;
            }
            else
            {
                offSetX = alternateFeet ? FOOTPRINT_SEPERATION : -FOOTPRINT_SEPERATION;
            }

            spriteFlip = DetermineSpriteFlip();

            print.transform.position = new Vector3(transform.position.x + offSetX, transform.position.y + offSetY, 0);
            print.transform.localEulerAngles = new Vector3(0, 0, angle);
            print.SetContent(footPrintSprite, spriteFlip);
            alternateFeet = !alternateFeet;
        }

        private float AngleBetweenVectors(Vector3 vec1, Vector3 vec2)
        {
            moveDifference = vec1 - vec2;
            Debug.Log(moveDifference);
            float sign = (vec1.y < vec2.y) ? -1.0f : 1.0f;
            return (Vector3.Angle(Vector3.right, moveDifference) * sign) + 90;
        }

        private bool DetermineSpriteFlip()
        {
            bool determiner = false;
            if(moveDifference.x > 0)
            {
                return determiner = (alternateFeet) ? true : false;
            }
            if(moveDifference.x < 0)
            {
                return determiner = (alternateFeet) ? false : true;
            }
            if(moveDifference.y > 0)
            {
               return determiner = (alternateFeet) ? false : true;
            }
            if (moveDifference.y < 0)
            {
                return determiner = (alternateFeet) ? true : false;
            }
            return determiner;
        }

    }
}
