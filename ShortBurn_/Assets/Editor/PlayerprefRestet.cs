using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class PlayerprefRestet

{
    [MenuItem("Tools/Restet playerPref")]

    public static void RestetPlayerPref()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("the PlayerPrefs Have been reset");
    }
}
