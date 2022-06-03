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
        [SerializeField] private GameObject playerModel;

        private CharacterController _controller;
        private Vector3 _playerVelocity;
        private bool _groundedPlayer;
        private bool _isCroushed;

        public bool _menuIsOpen;
        [SerializeField]private GameObject _timeMenu;
        
        private InputManager _inputManager;
        private Transform _cameraTransform;
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
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
            OpenMenu();
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

        private void OpenMenu()
        {
            if (_inputManager.OpenTimeMenu())
            {
                if (_menuIsOpen)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    _timeMenu.SetActive(false);
                    _menuIsOpen = false;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Confined;
                    _timeMenu.SetActive(true);
                    _menuIsOpen = true;
                }
            }
        }
        
        private void Crouch()
        {
            if (_inputManager.PlayerCrouch())
                Crouching();
            else
                StandingUp();
        }
        private void Crouching()
        {
            _isCroushed = true;
            _controller.height = 0.3f;
        }
        private void StandingUp()
        {
            _isCroushed = false;
            _controller.height = 2f;
        }
    }
}
