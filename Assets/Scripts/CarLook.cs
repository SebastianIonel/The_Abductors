using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLook : MonoBehaviour
{
    public Transform carBody;
    public float mouseSensitivity = 100f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;;

        carBody.Rotate(Vector3.up * mouseX);
    }
}
