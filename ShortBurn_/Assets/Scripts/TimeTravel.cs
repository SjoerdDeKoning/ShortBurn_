using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public enum Season
{
    Summer, Winter, Autumn, Spring
}
public class TimeTravel : MonoBehaviour
{
    [Header("Player Info")]
    public CharacterController player;
    
    [Header("Level info")]
    public GameObject summerLevel;
    public GameObject winterLevel;
    public GameObject autumnLevel;
    public GameObject springLevel;

    [SerializeField]private Vector3 levelOffset;

    [Header("SkyBox's")]
    [SerializeField]private Material skyboxSummer;
    [SerializeField]private Material skyboxWinter;
    [SerializeField]private Material skyboxAutumn;
    [SerializeField]private Material skyboxSpring;

    [Header(("Warp info"))]
     [Tooltip("Time in seconds"),SerializeField] private float warpTimeDelay;

    [Header("Events / Triggers")] 
    public UnityEvent beforeTImeWarp;
    public UnityEvent onTimeWarp;

    private void Start()
    {
        winterLevel.transform.position += levelOffset;
        autumnLevel.transform.position += levelOffset * 2;
        springLevel.transform.position += levelOffset * 3;
    }

    
    
    /// <summary>
    ///  Will warp the Player to the given "season"
    /// </summary>
    /// <param name="season"> the season you want to travel to</param>
    public async void TimeWarp(Season season)
    {                      
        player.enabled = false;
        Vector3 playerToLevel = player.transform.localPosition;
        switch (season) 
        {
            case Season.Summer:
                player.transform.SetParent(summerLevel.transform);
                if (skyboxSummer != null)
                {
                    RenderSettings.skybox = skyboxSummer;                   
                }
                break;
            case Season.Winter:
                player.transform.SetParent(winterLevel.transform);
                if (skyboxWinter != null)
                {
                    RenderSettings.skybox = skyboxWinter;                   
                }
                break;
            case Season.Autumn:
                player.transform.SetParent(autumnLevel.transform);
                if (skyboxAutumn != null)
                {
                    RenderSettings.skybox = skyboxAutumn;                   
                }
                break;
            case Season.Spring:
                player.transform.SetParent(summerLevel.transform);
                if (skyboxSpring!= null)
                {
                    RenderSettings.skybox = skyboxSpring;                   
                }
                break;
        }
        beforeTImeWarp.Invoke();
        await Task.Delay(TimeSpan.FromSeconds(warpTimeDelay));
        onTimeWarp.Invoke();
        player.transform.localPosition = playerToLevel;
        player.enabled = true;
    }
}
