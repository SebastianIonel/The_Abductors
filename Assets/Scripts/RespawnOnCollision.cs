using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RespawnOnCollision : MonoBehaviour
{
    [SerializeField] private Vector3 respawnPosition;
    [SerializeField] private CharacterController characterController;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {

            characterController.enabled = false;
            coll.gameObject.transform.position = respawnPosition;
            characterController.enabled = true;
        }
    }
}