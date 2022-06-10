using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class KeyItemController : MonoBehaviour
{
    [SerializeField] private bool mainDoor = false;
    [SerializeField] private bool mainKey = false;
    [SerializeField] private bool basementDoor = false;
    [SerializeField] private bool basementKey = false;
    [SerializeField] private bool gardenDoor = false;
    [SerializeField] private bool gardenKey = false;
    
    [FormerlySerializedAs("_keyInventory")] [SerializeField] private KeyInventory keyInventory;

    private KeyDoorController _mainDoorObject;
    private KeyDoorController _basementDoorObject;
    private KeyDoorController _gardenDoorObject;

    public GameObject mainKeyGameObject;
    public GameObject basementKeyGameObject;
    public GameObject gardenKeyGameObject;

    private void Start()
    {
        if (mainDoor)
        {
            _mainDoorObject = GetComponent<KeyDoorController>();
        }
        else if (gardenDoor)
        {
            _gardenDoorObject = GetComponent<KeyDoorController>();
        }
        else if (gardenDoor)
        {
            _gardenDoorObject = GetComponent<KeyDoorController>();
        }
    }

    public void ObjectInteraction()
    {
        if (mainDoor)
        {
            _mainDoorObject.OpenDoor();
            mainKeyGameObject.SetActive(false);
            keyInventory.hasMainKey = false;
        }
        else if (mainKey)
        {
            keyInventory.hasMainKey = true;
        }

        if (basementDoor)
        {
            _basementDoorObject.OpenDoor();
            basementKeyGameObject.SetActive(false);
        }
        else if (basementKey)
        {
            keyInventory.hasBasementKey = true;
        }
        
        if(gardenDoor)
        {
            _gardenDoorObject.OpenDoor();
        }
        else if (gardenKey)
        {
            keyInventory.hasGardenKey = true;
        }
    }
}
