using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Platform Type", menuName = "Platform Type")]
public class PlatformType : ScriptableObject
{
    public Color platformColor;
    public Vector3 platformScale;
    public bool isBreakable;
}