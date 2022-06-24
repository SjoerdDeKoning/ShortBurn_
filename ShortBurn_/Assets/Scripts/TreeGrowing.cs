using System.Collections;
using System.Collections.Generic;
using puzzle;
using UnityEngine;

public class TreeGrowing : MonoBehaviour
{
    public bool allowedToGrow = false;
    public bool doneGrowing = false;
    
    public float maxSize;
    public float growFactor;

    public PuzzleManager puzzleManager;

    public AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        if (allowedToGrow == true)
        {
            StartCoroutine(ScaleToSize());
        }
    }

    IEnumerator ScaleToSize()
    {
        float timer = 0;
        allowedToGrow = false;
        audioSource.Play();
        while(maxSize > transform.localScale.x)
        {
            timer += Time.deltaTime;
            transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
            yield return null;
        }
        puzzleManager.GardenKeySpawn();
        audioSource.Stop();
        yield return null;
       
    }
}
