using UnityEngine;

namespace Player_Controls
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Player Info")]
        [SerializeField]private float playerSpeed = 2.0f;
        [SerializeField]private float gravityValue = -9.81f;
        [SerializeField] private float crouchHeight = 0.5f;
    
        private CharacterController _controller;
        private Vector3 _playerVelocity;
        private bool _groundedPlayer;

        private InputManager _inputManager;
        private Transform _cameraTransform;
        private void Start()
        {
            _controller = GetComponent<CharacterController>();
            _inputManager = InputManager.instance;
            _cameraTransform = Camera.main.transform;
        }
        public void Update()
        {
            GroundCheck();
            Movement();
            Gravity();
            Crouch();
        }
        private void GroundCheck()
        {
            _groundedPlayer = _controller.isGrounded;
            if (_groundedPlayer && _playerVelocity.y < 0)
            {
                _playerVelocity.y = 0f;
            }
        }
        private void Movement()
        {
            Vector2 movement = _inputManager.GetPlayerMovement();
            Vector3 move = new Vector3(movement.x, 0f, movement.y);
            move = _cameraTransform.forward * move.z + _cameraTransform.right * move.x;
            move.y = 0;
            _controller.Move(move * (Time.deltaTime * playerSpeed));
        }
        private void Gravity()
        {
            _playerVelocity.y += gravityValue * Time.deltaTime;
            _controller.Move(_playerVelocity * Time.deltaTime);            
        }
        private void Crouch()
        {
            transform.localScale = _inputManager.PlayerCrouch() ? new Vector3(1f, crouchHeight, 1) : new Vector3(1f, 1f, 1f);
        }
    }
}
