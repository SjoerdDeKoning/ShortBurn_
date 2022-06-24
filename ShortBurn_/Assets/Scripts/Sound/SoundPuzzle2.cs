using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPuzzle2 : MonoBehaviour
{
    public AudioSource PuzzleSound;

    public float timer;
    public float targetTime;

    public bool doingPuzzle = false;

    private void Update()
    {
        if (doingPuzzle)
        {
            timer += Time.deltaTime;
            if (timer >= targetTime)
            {
                PuzzleSound.Play();
                timer = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>())
        {
            doingPuzzle = true;
        }
    }
}
