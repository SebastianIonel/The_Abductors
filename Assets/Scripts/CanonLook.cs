using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonLook : MonoBehaviour
{
    public float mouseSensitivity = 200f;
    public Transform playerBody;
    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 80f);

        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -90f , 80f);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
