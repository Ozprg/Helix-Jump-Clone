using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private IEnumerable<IBreakable> BreakablePlatforms { get; set; }
    private IEnumerable<IPlatform> Platforms { get; set; }
    
    private void Awake()
    {
        BreakablePlatforms = GetComponentsInChildren<IBreakable>();
        Platforms = GetComponentsInChildren<IPlatform>();   
    }
    public void BreakPlatform(IBreakable breakablePlatform)
    {
        breakablePlatform.Break(breakablePlatform); 
        EventManager.Instance.PointCollected();
    }
    public void BreakOtherPlatformsAtTheLevelOfCollision(IPlatform platform)
    {
        foreach (IPlatform platforms in Platforms)
        {
            if (platforms != platform && platforms.PlatformPosition.y == platform.PlatformPosition.y)
            {
                BreakPlatform((IBreakable)platforms);
            }
        }
    }
    public void BreakOtherPlatformsAboveThePlayer(IInvisibleBarrier barrier)
    {
        foreach (IPlatform platforms in Platforms)
        {
            if (platforms.PlatformPosition.y > barrier.BarrierPosition.y)
            {
                BreakPlatform((IBreakable)platforms);
            }
        }
    }
    public void BreakFinalPlatform()
    {
        EventManager.Instance.LevelCompleted();
    }
}