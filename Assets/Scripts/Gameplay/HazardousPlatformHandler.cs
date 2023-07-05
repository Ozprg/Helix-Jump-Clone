using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardousPlatformHandler : CollusionBase, IPlatform
{
    [SerializeField] private PlatformType platformType;
    private PlatformManager platformManager;
    public Vector3 PlatformPosition { get; set; }
    public bool IsPlatformSafe { get; set; }
    public Transform PlatformTransform { get; set; }

    private void Awake()
    {
        platformManager = GetComponentInParent<PlatformManager>();
        PlatformPosition = transform.position;
        IsPlatformSafe = false;
    }
    protected override void DetectCollision(Collision other)
    {
        IPlayer player = other.gameObject.GetComponent<IPlayer>();
        if (player != null && !IsPlatformSafe)
        {
            player.DestroyPlayer();
            EventManager.Instance.LevelFailed();
        }
    }
}
