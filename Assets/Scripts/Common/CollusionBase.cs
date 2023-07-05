using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollusionBase : MonoBehaviour, IBreakable
{
    private void OnCollisionEnter(Collision other)
    {
        if (other != null)
        {
            DetectCollision(other);
        }
    }
    protected abstract void DetectCollision(Collision other);
    public void Break(IBreakable platform)
    {
        gameObject.SetActive(false);
    }
}