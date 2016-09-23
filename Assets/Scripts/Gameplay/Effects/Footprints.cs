//App
using RENEGADES.Common;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Effects
{
    //This script is used to create footprints behind a moving sprite character
    public class Footprints : MonoBehaviour
    {
        [Header("Sprite for Footprint")]
        public Sprite footPrintSprite;

        [Header("Footprint GameObject")]
        public Footprint footPrintPrefab;

        [Header("Size")]
        [Range(0.0F, 2.0F)]
        public float size;

        private ObjectPooler pooler;
        private ObjectPooler Pooler
        {
            get { return pooler ?? (pooler = GetComponent<ObjectPooler>()); }
        }

        private const float FOOTPRINT_TIMER = 0.2f;
        private const float DISTANCE_THRESHOLD = 0.05f;

        private Vector3 lastPosition;
        private Vector3 moveDifference;

        private bool alternateFeet;
        private bool spriteFlip;

        private const float FOOTPRINT_SEPERATION = 0.1f;

        private void Awake()
        {
            InvokeRepeating("CheckFootPrint_OnUpdate", 0, FOOTPRINT_TIMER);
            lastPosition = transform.position;
        }

        //Check footprints on update (invoke)
        private void CheckFootPrint_OnUpdate()
        {
            if (transform.position != lastPosition)
            {
                Spawn(AngleBetweenVectors(lastPosition, transform.position));
            }
            lastPosition = transform.position;
        }

        //Spawn our footprint at the appropriate position
        private void Spawn(float angle)
        {
            Footprint print = Pooler.GetPooledObject().GetComponent<Footprint>();

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
            print.SetContent(footPrintSprite, spriteFlip,size);
            alternateFeet = !alternateFeet;
        }

        //Get our angle between two vectors
        private float AngleBetweenVectors(Vector3 vec1, Vector3 vec2)
        {
            moveDifference = vec1 - vec2;
            float sign = (vec1.y < vec2.y) ? -1.0f : 1.0f;
            return (Vector3.Angle(Vector3.right, moveDifference) * sign) + 90;
        }

        //flipping sprite for feet
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
