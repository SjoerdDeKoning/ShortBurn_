using System.Collections;
using System.Collections.Generic;
using System.Management.Instrumentation;
using UnityEngine;
//this was needed to test the timetravel :D
// if it all work you can delete this 
public class TempUImanger : MonoBehaviour
{
    public TimeTravel travel;
    public PauseMenu pauseMenu;

    public SoundManager soundManager;
    public string warpSoundName;

    public void WarpSummer()
    {
        travel.TimeWarp(Season.Summer);
        pauseMenu.isWinter = false;
        soundManager.Play(warpSoundName);
    }

    public void WarpWinter()
    {
        travel.TimeWarp(Season.Winter);
    }

    public void WarpSpring()
    {
        travel.TimeWarp(Season.Spring);
        pauseMenu.isWinter = true;
        soundManager.Play(warpSoundName);
    }

    public void WarpAutumn()
    {
        travel.TimeWarp(Season.Autumn);
    }

    public void test(string msg)
    {
        Debug.Log(msg);
    }
}
