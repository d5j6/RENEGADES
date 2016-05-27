//App
using RENEGADES.Constants;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Players
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D rigidBody;
        private Rigidbody2D  PlayerRigidBody
        {
            get { return rigidBody ?? (rigidBody = GetComponent<Rigidbody2D>()); }
        }

        public class MoveParams
        {
            public float rightJoyStickX { get; set; }
            public float rightJoyStickY { get; set; }
        }

        private float LeftJoyStickX;
        private float LeftJoyStickY;

        private const float MaxSpeed = 0.25f;
        private float ForceAdd = 200f;

        private const float DRAG = 30f;

        MoveParams moveParams;

        private void Awake()
        {
            PlayerRigidBody.drag = DRAG;
            moveParams = new MoveParams();
        }

        private void Update()
        {
            LeftJoyStickX = Input.GetAxis(GameInput.GetInput(GameInput.PlayerInput.LeftJoyHorizontal));
            LeftJoyStickY = -Input.GetAxis(GameInput.GetInput(GameInput.PlayerInput.LeftJoyVertical));
            moveParams.rightJoyStickX = Input.GetAxis(GameInput.GetInput(GameInput.PlayerInput.RightJoyHoriztonal));
            moveParams.rightJoyStickY = -Input.GetAxis(GameInput.GetInput(GameInput.PlayerInput.RightJoyVertical));
        }

        // Update is called once per frame
        public MoveParams Move()
        {
            PlayerRigidBody.AddForce((Vector2.right*LeftJoyStickX)* ForceAdd);
            PlayerRigidBody.AddForce((Vector2.up * LeftJoyStickY) * ForceAdd);
            PlayerRigidBody.velocity = Vector3.ClampMagnitude(PlayerRigidBody.velocity, MaxSpeed);
            return moveParams;
        }

        private void OnDestroy()
        {
            rigidBody = null;
        }
    }
}
