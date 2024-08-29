using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RespawnOnCollision : MonoBehaviour
{
    [SerializeField] private Vector3 playerRespawnPosition;
    [SerializeField] private Vector3 carRespawnPosition;
    [SerializeField] private CharacterController playerController;
    [SerializeField] private CharacterController carController;

    public PickupItem item;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            playerController.enabled = false;
            coll.gameObject.transform.position = playerRespawnPosition;
            playerController.enabled = true;
        } else if (coll.CompareTag("Car")) {
            carController.enabled = false;
            coll.gameObject.transform.position = carRespawnPosition;
            carController.enabled = true;
        }
        item.DropItem();
    }
}