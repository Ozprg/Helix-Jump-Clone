using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBarrierHandler : MonoBehaviour, IInvisibleBarrier
{
    private PlatformManager platformManager;
    private Collider invisibleBarrierCollider;
    public Vector3 BarrierPosition { get; set; }

    private void Awake()
    {
        platformManager = GetComponentInParent<PlatformManager>();
        invisibleBarrierCollider = GetComponent<Collider>();
        BarrierPosition = this.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IPlayer>() != null)
        {
            BreakThePlatformAbove();
            DisableInvisibleBarrier();
        }
    }
    public void BreakThePlatformAbove()
    {
        platformManager.BreakOtherPlatformsAboveThePlayer(this);
    }
    private void DisableInvisibleBarrier()
    {
        this.invisibleBarrierCollider.enabled = false;
    }
}