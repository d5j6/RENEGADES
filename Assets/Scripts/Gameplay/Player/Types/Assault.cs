//Unity
using UnityEngine;

//Game
using RENEGADES.Gameplay.Weapons;
using RENEGADES.Constants;
using RENEGADES.Managers;


namespace RENEGADES.Gameplay.Players.Types
{
    public class Assault : Player
    {
        private RangedAttack rangedAttack;
        private RangedAttack RangedAttack
        {
            get { return rangedAttack ?? (rangedAttack = GetComponentInChildren<RangedAttack>()); }
        }

        private BombPlanter planter;
        private BombPlanter Planter
        {
            get { return planter ?? (planter = GetComponentInChildren<BombPlanter>()); }
        }



        public override void OnUpdate()
        {
            base.OnUpdate();
            RangedAttackLoop();
            BombPlantLoop();

        }


        private void RangedAttackLoop()
        {

            if (GameManager.Instance._ControllerManager.AnyControllersConnected())
            {
                if (Input.GetAxis(GameInput.GetInput(GetPlayerNumber(),GameInput.PlayerInput.Attack)) > 0)
                {
                    RangedAttack.FIRE(this);
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.Space)) RangedAttack.FIRE(this);
            }

        }

        private void BombPlantLoop()
        {
            
            if (GameManager.Instance._ControllerManager.AnyControllersConnected())
            {
                if (Input.GetAxis(GameInput.GetInput(GetPlayerNumber(),GameInput.PlayerInput.CharacterSpecial)) > 0)
                {
                    Planter.PlantBomb();
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.X)) Planter.PlantBomb();
            }
        }

    }
}
