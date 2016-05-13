//App
using RENEGADES.Constants;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D rigidBody;
        private Rigidbody2D  RigidBody
        {
            get { return rigidBody ?? (rigidBody = GetComponent<Rigidbody2D>()); }
        }

        private Vector3 InputDirection;

        private const float AXIS_THRESHOLD = 0.05f;

        private float LeftJoyStickX;
        private float LeftJoyStickY;

        private void Awake()
        {
            InputDirection = Vector3.zero;
        }
        // Update is called once per frame
        private void FixedUpdate()
        {
            LeftJoyStickX = Input.GetAxis(GameInput.GetInput(GameInput.PlayerInput.LeftJoyHorizontal));
            if (Mathf.Abs(LeftJoyStickX) > 0.05f)
            {
                InputDirection.x = LeftJoyStickX;
                transform.position += InputDirection/15;
            }
            LeftJoyStickY = Input.GetAxis(GameInput.GetInput(GameInput.PlayerInput.LeftJoyVertical));
            if (Mathf.Abs(LeftJoyStickY) > 0.05f)
            {
                InputDirection.y = -LeftJoyStickY;
                transform.position += InputDirection/15;
            }

        }

        private void OnDestroy()
        {
            rigidBody = null;
        }
    }
}
