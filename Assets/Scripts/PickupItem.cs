using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float pickupDistance = 2f;
    [SerializeField] private LayerMask pickupLayer;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit raycastHit, pickupDistance, pickupLayer)) {
                if (raycastHit.transform.CompareTag("Item")) {
                    Debug.Log("item!");
                }
            }
        }
    }
}
