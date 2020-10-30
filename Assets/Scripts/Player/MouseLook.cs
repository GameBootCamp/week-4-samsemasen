using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;

    private void Start()
    {
        // hide and lock curser to center of the screen // use ctrl + p to exit play mode on unity engine
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        // get mouse inputs
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // look up and down --> rotate around the x axis
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // look left and right --> rotate around the y axis (vector3.up)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
