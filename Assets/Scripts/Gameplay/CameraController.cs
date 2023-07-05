using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 offset;
    private void Update()
    {
        Vector3 desiredPosition = new Vector3(transform.position.x, playerTransform.position.y, transform.position.z);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, float.MinValue, playerTransform.position.y);
        transform.position = desiredPosition;
    }
}
