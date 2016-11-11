//Unity
using UnityEngine;

//Game
using RENEGADES.Gameplay.Effects;
using RENEGADES.Managers;
using RENEGADES.Constants;
using RENEGADES.Gameplay.Players;

namespace RENEGADES.Gameplay.Weapons.Turrets
{
    /// <summary>
    /// Turret Builder for Engineer
    /// </summary>
    public class TurretBuilder : MonoBehaviour
    {
        private SpriteRenderer sprite;
        private SpriteRenderer Sprite
        {
            get { return sprite ?? (sprite = GetComponent<SpriteRenderer>()); }
        }

        private Player player;
        private Player _Player
        {
            get { return player ?? (player = GetComponentInParent<Player>()); }
        }

        private bool building;
        private bool clearBuild = true;

        private const float BLOCK_DISTANCE = 0.75f;

        private Vector3 buildPosition;

        private void Update()
        {
            Sprite.enabled = building;
            Sprite.color = clearBuild ? Color.blue : Color.red;
        }

        public void Building(bool building)
        {
            this.building = building;
            if (!building) return;
            SetBlockSide();
            if (!clearBuild) return;
            if (TryingToBuild()) BUILD();

        }

        private void SetBlockSide()
        {
            float x = 0; float y = 0;
            //Based on players animation trigger
            switch (_Player.CurrentTrigger)
            {
                case AnimationTriggers.PlayerAnimation.Left:
                    x = -BLOCK_DISTANCE; y = 0;
                    break;
                case AnimationTriggers.PlayerAnimation.Right:
                    x = BLOCK_DISTANCE; y = 0;
                    break;
                case AnimationTriggers.PlayerAnimation.Up:
                    x = 0; y = BLOCK_DISTANCE;
                    break;
                case AnimationTriggers.PlayerAnimation.Down:
                    x = 0; y = -BLOCK_DISTANCE;
                    break;
            }
            transform.localPosition = new Vector3(x, y, 0);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            clearBuild = false;
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            clearBuild = true;
        }

        private bool TryingToBuild()
        {
            bool justBuilt = false;
            if (GameManager.Instance._ControllerManager.AnyControllersConnected())
            {
                justBuilt = (Input.GetButtonDown(GameInput.GetInput(GameInput.PlayerInput.Build))) ? true : false;
            }
            else
            {
                justBuilt = (Input.GetKeyDown(KeyCode.C)) ? true : false;
            }
            return justBuilt;
        }

        private void BUILD()
        {
            if (_Player.GetCrystals() < 10) return;
            _Player.UpdateCrystals(-10);
            GameManager.Instance.EffectSpawner.CreateEffect(EffectBlueprint.EffectType.Build, transform.position);
            GameManager.Instance.AudioManager.PlaySound(Audio.Sounds.Sound.Build);
            buildPosition = transform.position;
            Invoke("DelaySpawn", 0.5f);
        }

        private void DelaySpawn()
        {
            GameManager.Instance.TurretSpawner.CreateTurret(AI.Turrets.TurretType.TurretKey.Basic, buildPosition);
        }




    }
}
