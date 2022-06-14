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

    public KeyDoorController mainDoorObject;
    public KeyDoorController basementDoorObject;
    public KeyDoorController gardenDoorObject;

    public GameObject mainKeyGameObject;
    public GameObject basementKeyGameObject;
    public GameObject gardenKeyGameObject;

    

    public void ObjectInteraction()
    {
        if (mainDoor)
        {
            mainDoorObject.OpenDoor();
            mainKeyGameObject.SetActive(false);
            keyInventory.hasMainKey = false;
        }
        else if (mainKey)
        {
            keyInventory.hasMainKey = true;
        }

        if (basementDoor)
        {
            basementDoorObject.OpenDoor();
            basementKeyGameObject.SetActive(false);
            keyInventory.hasGardenKey = false;
        }
        else if (basementKey)
        {
            keyInventory.hasBasementKey = true;
        }
        
        if(gardenDoor)
        {
            Debug.Log("Here comes the next scene");
        }
        else if (gardenKey)
        {
            keyInventory.hasGardenKey = true;
        }
    }
}
