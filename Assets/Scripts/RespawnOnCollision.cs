using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RespawnOnCollision : MonoBehaviour
{
    [SerializeField] private Vector3 respawnPosition;
    [SerializeField] private CharacterController characterController;

    public PickupItem item;
    public GetPosition car;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            characterController.enabled = false;
            //coll.gameObject.transform.position = respawnPosition;
            coll.gameObject.transform.position = car.GetPos();
            characterController.enabled = true;
            item.DropItem();
        }
    }
}