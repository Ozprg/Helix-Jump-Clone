using UnityEngine;
public class SafePlatformHandler : CollusionBase, IPlatform
{
    [SerializeField] private PlatformType platformType;
    [SerializeField] private float thresholdBreakSpeed;
    public bool IsPlatformSafe { get; set;}
    public Vector3 PlatformPosition { get; set; }
    public Transform PlatformTransform { get; set; }
    private PlatformManager platformManager;
    private void Awake()
    {
        platformManager = GetComponentInParent<PlatformManager>();
        GetComponent<Renderer>().material.color = platformType.platformColor;
        GetComponent<Transform>().lossyScale.Set(platformType.platformScale.x, platformType.platformScale.y, platformType.platformScale.z);       
        GetComponent<Rigidbody>().useGravity = false;    
    }
    private void Start()
    {
        PlatformTransform = this.transform;
        PlatformPosition = this.transform.position;

        platformType.isBreakable = false;
        IsPlatformSafe = true;
    }
    protected override void DetectCollision(Collision other)
    {
        IPlayer player = other.gameObject.GetComponent<IPlayer>();

        if (player != null)
        {
            if (player.PlayerSpeed > thresholdBreakSpeed && platformType.isBreakable)
            {
                platformManager.BreakPlatform(this);
                platformManager.BreakOtherPlatformsAtTheLevelOfCollision(this);
            }
            EventManager.Instance.PlatformPassed(this);
        }
    }
}