using System.Collections;
using UnityEngine;

public class FinalPlatformHandler : CollusionBase
{
    PlatformManager platformManager;
    private void Awake()
    {
        platformManager = GetComponentInParent<PlatformManager>();
    }
    protected override void DetectCollision(Collision other)
    {
        IPlayer player = other.gameObject.GetComponent<IPlayer>();
        if (player != null)
        {
            platformManager.BreakFinalPlatform();
        }      
    }
}