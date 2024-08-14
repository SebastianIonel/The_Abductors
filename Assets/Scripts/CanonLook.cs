using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonLook : MonoBehaviour
{
    public float mouseSensitivity = 200f;
    private float xRotation = 0f;
    private float yRotation = 0f;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private float verticalOffset;
    [SerializeField] private MeteorGun meteorGun;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!meteorGun.isFiring) {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -40f, 40f);

            yRotation += mouseX;
            yRotation = Mathf.Clamp(yRotation, -60f, 60f);

            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

            shootingPoint.localRotation = Quaternion.Euler(xRotation + verticalOffset, yRotation, 0f);
        }
    }
}
