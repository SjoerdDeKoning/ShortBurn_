using Helper_Scripts;
using UnityEngine;

namespace Player_Controls
{
    /// <summary>
    ///  This script is used if you want to use the input values.
    ///  We instantiate the PlayerControls here so there is only one script running and instated the playerControls
    /// </summary>
    public class InputManager : SingletonBehaviour<InputManager>
    {
        private PlayerControls _playerControls;

        protected override void Awake()
        {
            base.Awake();
            _playerControls = new PlayerControls();
        }

        private void OnEnable()
        {
            _playerControls.Enable();
        }
        private void OnDisable()
        {
            _playerControls.Disable();
        }

        /// <summary>
        /// Get Movement value as a Vector2. 
        /// </summary>
        /// <returns> Returns the Vector2 form the Player Movement </returns>
        public Vector2 GetPlayerMovement()
        {
            return _playerControls.Player.Movement.ReadValue<Vector2>();
        }

        /// <summary>
        /// Get the mouseDelta Input as a Vector2
        /// </summary>
        /// <returns> Returns the Vector2 from the Player Movement </returns>
        public Vector2 GetMouseDelta()
        {
            return _playerControls.Player.Look.ReadValue<Vector2>();
        }

        /// <summary>
        /// Get the Crouch Input as a Bool 
        /// </summary>
        /// <returns> Returns the Bool from the Player Movement  </returns>
        public bool PlayerCrouch()
        {
            return _playerControls.Player.Crouch.inProgress;
        }

        public bool PickupItem()
        {
            return _playerControls.Player.UseIitem.triggered;
        }
    }
}
