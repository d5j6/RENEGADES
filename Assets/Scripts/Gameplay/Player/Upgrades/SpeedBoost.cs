//Unity
using UnityEngine;

//Game
using RENEGADES.Common;
using RENEGADES.Managers;

namespace RENEGADES.Gameplay.Players.Upgrades
{
    public class SpeedBoost : MonoBehaviour
    {

        private float JUICE;

        private TrailRenderer speedTrail;
        private TrailRenderer SpeedTrail
        {
            get { return speedTrail ?? (speedTrail = GenComponent.ComponentCheck<TrailRenderer>(gameObject)); }
        }

        private PlayerMovement playerMovement;
        private PlayerMovement PlayerMove
        {
            get { return playerMovement ?? (playerMovement = GetComponent<PlayerMovement>()); }
        }

        private const float STARTINGJUICE = 10;
        private const float STARTTIME = 0.5f;
        private const float END_WIDTH = 2.0f;

        private void Awake()
        {
            PlayerMove.SetForce(true);
            JUICE = STARTINGJUICE;
            SetUpTrail();
        }

        private void SetUpTrail()
        {
            SpeedTrail.material = GameManager.Instance.EffectSpawner.defaultParticleMAT;
            SpeedTrail.time = 0.5f;
            SpeedTrail.startWidth = 0.1f;
            SpeedTrail.endWidth = 2.0f;
        }

        private void Update()
        {
            TrailSize();
            JUICE -= Time.deltaTime;
            if(JUICE < 0) { Dispose(); }
        }

        private void TrailSize()
        {
            SpeedTrail.time = Mathf.Clamp((JUICE / STARTINGJUICE) * STARTTIME, 0, STARTTIME);
            SpeedTrail.endWidth = Mathf.Clamp((JUICE /(STARTINGJUICE/END_WIDTH)) / END_WIDTH, 0, END_WIDTH);
        }

        public void AddJuice()
        {
            JUICE += 2.5f;
        }

        private void Dispose()
        {
            PlayerMove.SetForce(false);
            Destroy(SpeedTrail);
            Destroy(this);
        }
    }
}
