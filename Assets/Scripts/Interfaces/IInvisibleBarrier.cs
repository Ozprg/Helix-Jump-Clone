using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInvisibleBarrier
{
    Vector3 BarrierPosition { get; set; }
    void BreakThePlatformAbove();
}
