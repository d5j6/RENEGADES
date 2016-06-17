//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Effects
{

    public class PlayerFootprints : MonoBehaviour
    {
        private Footprints footprints;
        private Footprints FootPrints
        {
            get { return footprints ?? (footprints = GetComponent<Footprints>()); }
        }

        private const float footprintSpacing = 0.5f; // distance between each footprint

        private Vector3 lastPos = Vector3.zero;

        private void Awake()
        {
            lastPos = transform.position;
        }

        private void Update()
        {
            float distFromLastFootprint = (lastPos - transform.position).sqrMagnitude;

            if (distFromLastFootprint > footprintSpacing * footprintSpacing)
            {
                //footprints.AddFootprint( transform.position, transform.forward, transform.right, 0 );
                FootPrints.AddFootprint(transform.localPosition, transform.forward, transform.right, Random.Range(0, 4));
                Debug.Log("PLACE");
                lastPos = transform.position;
            }
        }
    }
}
