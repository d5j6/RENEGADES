//App
using RENEGADES.Constants;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D rigidBody;
        private Rigidbody2D  PlayerRigidBody
        {
            get { return rigidBody ?? (rigidBody = GetComponent<Rigidbody2D>()); }
        }

        private float LeftJoyStickX;
        private float LeftJoyStickY;

        private const float MaxSpeed = 2.5f;
        private float ForceAdd = 300f;

        private const float DRAG = 30f;

        private void Awake()
        {
            PlayerRigidBody.drag = DRAG;
        }

        private void Update()
        {
            LeftJoyStickX = Input.GetAxis(GameInput.GetInput(GameInput.PlayerInput.LeftJoyHorizontal));
            LeftJoyStickY = -Input.GetAxis(GameInput.GetInput(GameInput.PlayerInput.LeftJoyVertical));
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            PlayerRigidBody.AddForce((Vector2.right*LeftJoyStickX)* ForceAdd);
            PlayerRigidBody.AddForce((Vector2.up * LeftJoyStickY) * ForceAdd);
            PlayerRigidBody.velocity = Vector3.ClampMagnitude(PlayerRigidBody.velocity, MaxSpeed);

        }

        private void OnDestroy()
        {
            rigidBody = null;
        }
    }
}
