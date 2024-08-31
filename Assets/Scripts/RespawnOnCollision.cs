using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RespawnOnCollision : MonoBehaviour
{
    [SerializeField] private Transform car;
    [SerializeField] private Vector3 respawnPosition;
    [SerializeField] private CharacterController playerController;
    [SerializeField] private CharacterController carController;

    public PickupItem item; 

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            if (car) {
                playerController.enabled = false;
                coll.gameObject.transform.position = respawnPosition + new Vector3(5f, 0, 0);
                playerController.enabled = true;

                carController.enabled = false;
                car.position = respawnPosition;
                carController.enabled = true;
            } else {
                playerController.enabled = false;
                coll.gameObject.transform.position = respawnPosition;
                playerController.enabled = true;
            }
        } else if (coll.CompareTag("Car")) {
            carController.enabled = false;
            coll.gameObject.transform.position = respawnPosition;
            carController.enabled = true;
        }
        if (item) {
            item.DropItem();
        }
    }
}