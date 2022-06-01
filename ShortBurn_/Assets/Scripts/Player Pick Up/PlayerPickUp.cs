using Player_Controls;
using UnityEngine;
using UnityEngine.Events;

namespace Player_Pick_Up
{
    public class PlayerPickUp : MonoBehaviour
    {
        public GameObject pickable;
        public GameObject playerHands;
        public UnityEvent onItemPickup;
        public Camera playerCamera;
        public float raycastMaxDistance;

        private InputManager _input;
        private void Start()
        {
            playerCamera = Camera.main;
            _input = InputManager.instance;
        }

        private void Update()
        {
            if (_input.PickupItem())
            {
                TryPickUp();
            }
        }
        private void TryPickUp()
        {
            if (_input.PickupItem())
            {
                if (pickable)
                {
                    DropPickedUpItem(pickable);
                }
                else
                {
                    Ray ray = playerCamera.ViewportPointToRay(Vector3.forward );;
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, raycastMaxDistance))
                    {
                        var pickableItem = hit.transform.GetComponent<PickUpItem>();
                        if (pickableItem)
                        {
                            pickable = pickableItem.gameObject;
                            PickUpItem(pickable);
                        }
                    }
                }
            }
        }

        private void DropPickedUpItem(GameObject item)
        {
            pickable = null;
            item.transform.SetParent(null);
            item.GetComponent<PickUpItem>().GetRigidbody.AddForce(item.transform.forward * 2,ForceMode.VelocityChange);
        }
        
        private void PickUpItem(GameObject item)
        {
            item.transform.parent = playerHands.transform;
            item.transform.localPosition = Vector3.zero;
            item.transform.eulerAngles = Vector3.zero;
        }
    }
}
