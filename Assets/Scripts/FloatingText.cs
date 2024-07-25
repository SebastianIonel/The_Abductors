using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    private Transform playerCamera;
    private Transform unit;
    private Transform canvas;

    public Vector3 offset;

    void Start()
    {
        playerCamera = Camera.main.transform;
        unit = transform.parent;
        canvas = GameObject.FindObjectOfType<Canvas>().transform;

        transform.SetParent(canvas);
    }

    void Update()
    {
        // Look at the player camera
        transform.rotation = Quaternion.LookRotation(transform.position - playerCamera.transform.position);

        // Text is at target position + offset
        transform.position = unit.position + offset;
    }
}
