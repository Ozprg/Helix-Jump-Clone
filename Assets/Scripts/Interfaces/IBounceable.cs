using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBounceable 
{
    public bool IsGrounded { get; set; }
    public void Bounce();
}
