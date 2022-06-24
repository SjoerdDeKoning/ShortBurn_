using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public GameObject MenuSound;
    
    public void PlayMenuSound()
    {
        MenuSound.GetComponent<AudioSource>().Play();
    }
}
