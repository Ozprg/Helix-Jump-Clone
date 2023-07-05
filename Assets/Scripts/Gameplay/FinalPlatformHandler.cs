using System.Collections;
using System.Collections.Generic;
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
            PlatformManager platformManager = GetComponentInParent<PlatformManager>();
            StartCoroutine(WaitaAfterFinalCollusion());
        }      
    }
    IEnumerator WaitaAfterFinalCollusion()
    {
        yield return new WaitForSeconds(1.5f);
        platformManager.BreakFinalPlatform();
    }
}
