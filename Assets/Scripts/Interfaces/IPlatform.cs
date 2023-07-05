using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlatform
{
    Transform PlatformTransform { get; set; }
    Vector3 PlatformPosition { get; set; }
    bool IsPlatformSafe { get; set; }
}
