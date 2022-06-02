using UnityEngine.Audio;
using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;

    public static SoundManager instance;
    
    /// <summary>
    /// When it is awake it will first check of there is just one of this script present
    /// Then it will set everything up like the audio source and the volume etc.
    /// it will do that in a Foreach
    /// </summary>
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.panStereo = s.stereoPan;
        }
    }

    private void Start()
    {
        Play("Unox");
    }

    /// <summary>
    /// Will first check of the giving name is existing
    /// if yes then it will play the sound
    /// if no then it will don't play the sound and give it an error
    /// </summary>
    /// <param name="name"> The name of the sound file</param>
    #region play
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError("no sound with the name + " + name);
            return;
        }
        s.source.Play();
        Debug.Log("Playing " + name);
    }
    #endregion

    /// <summary>
    /// Will first check of the giving name is existing
    /// will stop the sound when it is playing.
    /// </summary>
    /// <param name="name"> The name of the sound file</param>
    #region stop
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop(); 
        Debug.Log("Not Playing " + name);
    }
    #endregion
}
