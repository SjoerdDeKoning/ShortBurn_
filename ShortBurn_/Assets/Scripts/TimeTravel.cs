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
    
    [Header("Events / Triggers")]
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
    public void TimeWarp(Season season)
    {
        player.enabled = false;
        Vector3 playerToLevel = player.transform.localPosition;
        Debug.Log(playerToLevel);
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
        player.transform.localPosition = playerToLevel;
        onTimeWarp.Invoke();
        Debug.Log(player.transform.position);
        player.enabled = true;
    }
}
