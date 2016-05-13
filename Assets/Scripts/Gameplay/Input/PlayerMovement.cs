//App
using RENEGADES.Constants;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.PlayerInput
{
    public class PlayerMovement : MonoBehaviour
    {
        private Vector3 InputDirection;

        private const float AXIS_THRESHOLD = 0.05f;

        private void Awake()
        {
            InputDirection = Vector3.zero;
        }
        // Update is called once per frame
        private void Update()
        {
            float LeftJoyStickX = Input.GetAxisRaw(GameInput.GetInput(GameInput.PlayerInput.LeftJoyHorizontal));
            if (Mathf.Abs(LeftJoyStickX) > AXIS_THRESHOLD)
            {
                InputDirection.x = LeftJoyStickX;
                transform.position += InputDirection/15;
            }
            float LeftJoyStickY = Input.GetAxisRaw(GameInput.GetInput(GameInput.PlayerInput.LeftJoyVertical));
            if (Mathf.Abs(LeftJoyStickY) > AXIS_THRESHOLD)
            {
                InputDirection.y = -LeftJoyStickY;
                transform.position += InputDirection/15;
            }

        }
    }
}
