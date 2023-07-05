using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    private bool isRotating = false;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isRotating = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }

        if (isRotating)
        {
            float rotationAmount = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, rotationAmount);
        }
    }
}
