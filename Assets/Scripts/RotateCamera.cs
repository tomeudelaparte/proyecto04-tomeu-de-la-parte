using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 500;

    void Update()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");

        float horizontalInputMouse = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * horizontalInputMouse);
    }
}
