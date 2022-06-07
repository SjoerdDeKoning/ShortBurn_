using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemController : MonoBehaviour
{
    [SerializeField] private bool _Door = false;
    [SerializeField] private bool _key = false;

    [SerializeField] private KeyInventory _keyInventory = null;

    private KeyDoorController _DoorObject;

    public GameObject key;

    private void Start()
    {
        if (_Door)
        {
            _DoorObject = GetComponent<KeyDoorController>();
        }
    }

    public void ObjectInteraction()
    {
        if (_Door)
        {
            _DoorObject.OpenDoor();
            key.SetActive(false);
        }

        else if (_key)
        {
            _keyInventory.hasKey = true;
        }
    }
}
