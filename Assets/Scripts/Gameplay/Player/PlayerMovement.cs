//App
using RENEGADES.Constants;
using RENEGADES.Managers;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Players
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D rigidBody;
        private Rigidbody2D PlayerRigidBody
        {
            get { return rigidBody ?? (rigidBody = GetComponent<Rigidbody2D>()); }
        }

        //Will determine which way our character is facing
        public class LookParams
        {
            public float rightJoyStickX { get; set; }
            public float rightJoyStickY { get; set; }
        }

        private float LeftJoyStickX;
        private float LeftJoyStickY;

        private const float MaxSpeed = 0.25f;
        private float ForceAdd = 200f;

        private const float DRAG = 30f;

        LookParams lookParams;

        private void Awake()
        {
            PlayerRigidBody.drag = DRAG;
            lookParams = new LookParams();
        }

        private void Update()
        {
            //Xbox Controller
            if (GameManager.Instance.ControllerManager.AnyControllersConnected())
            {
                XboxController();
            }
            else //Keyboard
            {
                Keyboard();
            }

            
        }

        //movement and look controllers for no Xbox controller
        private void Keyboard()
        {
            //left and right
            if (Input.GetKey(KeyCode.A)) LeftJoyStickX = -1;
            else if(Input.GetKey(KeyCode.D)) LeftJoyStickX = 1;
            else { LeftJoyStickX = 0; }


            //up and down
            if (Input.GetKey(KeyCode.S)) LeftJoyStickY = -1;
            else if (Input.GetKey(KeyCode.W)) LeftJoyStickY = 1;
            else { LeftJoyStickY = 0; }

            //determine look direction
            lookParams.rightJoyStickX = Camera.main.ScreenPointToRay(Input.mousePosition).origin.x - transform.position.x;
            lookParams.rightJoyStickY = Camera.main.ScreenPointToRay(Input.mousePosition).origin.y - transform.position.y;

        }

        //movement controls for Xbox controller
        private void XboxController()
        {
            LeftJoyStickX = Input.GetAxis(GameInput.GetInput(GameInput.PlayerInput.MovementX));
            LeftJoyStickY = -Input.GetAxis(GameInput.GetInput(GameInput.PlayerInput.MovementY));
            lookParams.rightJoyStickX = Input.GetAxis(GameInput.GetInput(GameInput.PlayerInput.DirectionX));
            lookParams.rightJoyStickY = -Input.GetAxis(GameInput.GetInput(GameInput.PlayerInput.DirectionY));
        }

        //Called in player class
        public LookParams Move()
        {
            PlayerRigidBody.AddForce((Vector2.right * LeftJoyStickX) * ForceAdd);
            PlayerRigidBody.AddForce((Vector2.up * LeftJoyStickY) * ForceAdd);
            PlayerRigidBody.velocity = Vector3.ClampMagnitude(PlayerRigidBody.velocity, MaxSpeed);
            return lookParams;
        }

        private void OnDestroy()
        {
            rigidBody = null;
        }
    }
}
