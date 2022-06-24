using Control_and_Input;
using UnityEngine;

namespace Player_Controls
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Player Info")]
        [SerializeField]private float playerSpeed = 2.0f;
        [SerializeField]private float gravityValue = -9.81f;
        [SerializeField] private float crouchHeight = 0.3f;

        private CharacterController _controller;
        private Vector3 _playerVelocity;
        private bool _groundedPlayer;

        private InputManager _inputManager;
        private Transform _cameraTransform;

        public AudioSource walkingSfxWood;
        public AudioSource walkingSfxGrass;
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

            RaycastHit hit;
            if (Physics.Raycast(transform.position,Vector3.down,out hit,3f) && hit.transform.CompareTag("Grass"))
            {
                if (movement != Vector2.zero && !walkingSfxGrass.isPlaying)
                {
                    walkingSfxGrass.volume = Random.Range(0.25f, 0.5f);
                    walkingSfxGrass.pitch = Random.Range(0.8f, 1.2f);
                    walkingSfxGrass.Play();
                }
            }
            else
            {
                if (movement != Vector2.zero && !walkingSfxWood.isPlaying)
                {
                    walkingSfxWood.volume = Random.Range(0.25f, 0.5f);
                    walkingSfxWood.pitch = Random.Range(0.8f, 1.2f);
                    walkingSfxWood.Play();
                }
            }
        }
        private void Gravity()
        {
            _playerVelocity.y += gravityValue * Time.deltaTime;
            _controller.Move(_playerVelocity * Time.deltaTime);            
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
            _controller.height = crouchHeight;
        }
        private void StandingUp()
        {
            _controller.height = 2f;
        }
    }
}
