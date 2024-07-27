using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupItem : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float interactDistance = 2f;
    [SerializeField] private LayerMask interactLayer;
    [SerializeField] private TMP_Text message;
    [SerializeField] private FinishSpaceship spaceship;

    public GameObject currentItem;


    void Update()
    {
        
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit raycastHit, interactDistance, interactLayer)) {
            
            // Pointing towards an item
            if (raycastHit.transform.CompareTag("Item")) {
                message.SetText("Press `E` to pick up item.");
                message.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E)) {
                    currentItem = raycastHit.transform.gameObject;
                }
            
            // Pointing towards a multimeter
            } else if (raycastHit.transform.CompareTag("Multimeter")) {
                message.SetText("Press `E` to measure resistance value.");
                message.gameObject.SetActive(true);

                if (currentItem != null && Input.GetKeyDown(KeyCode.E)) {
                    raycastHit.transform.GetComponent<Multimeter>().MeasureResistance(currentItem);
                }
            
            // Pointing towards the spaceship
            } else if (raycastHit.transform.CompareTag("Spaceship")) {
                if (currentItem == null) {
                    message.SetText("Something is missing.");
                } else {
                    message.SetText("Press `E` to repair the Spaceship.");
                }
                message.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E)) {
                    spaceship.Repair(currentItem);
                }
            } else {
                message.gameObject.SetActive(false);
            }
        } else {
            message.gameObject.SetActive(false);
        }
    }
}
