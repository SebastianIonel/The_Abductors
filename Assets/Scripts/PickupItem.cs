using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float interactDistance = 2f;
    [SerializeField] private LayerMask interactLayer;

    public GameObject currentItem;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit raycastHit, interactDistance, interactLayer)) {
                if (raycastHit.transform.CompareTag("Item")) {
                    currentItem = raycastHit.transform.gameObject;
                }

                if (currentItem != null && raycastHit.transform.CompareTag("Multimeter")) {
                    raycastHit.transform.GetComponent<Multimeter>().MeasureResistance(currentItem);
                }
            }
        }
    }
}
