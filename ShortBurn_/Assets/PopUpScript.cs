using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpScript : MonoBehaviour
{
    public GameObject popUpText;
    public GameObject objectAttachedTo;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>())
        {
            popUpText.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<CharacterController>())
        {
            popUpText.SetActive(false);
        }
    }

    private void Update()
    {
        if (objectAttachedTo.transform.parent != null)
        {
            popUpText.SetActive(false);
        }
    }
}
