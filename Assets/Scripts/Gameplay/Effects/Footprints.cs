//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Effects
{
    public class Footprints : MonoBehaviour
    {

        private ParticleSystem footprints;
        private ParticleSystem FootPrintParticles
        {
            get { return footprints ?? (footprints = GetComponent<ParticleSystem>()); }
        }

        private bool FootPrintsEnabled;

        public void EnableFootPrints(bool enable)
        {
            FootPrintParticles.startLifetime = (enable) ? 2.5f : 0.0f;
        }

        private void OnDestroy()
        {
            footprints = null;
        }
    }
}
