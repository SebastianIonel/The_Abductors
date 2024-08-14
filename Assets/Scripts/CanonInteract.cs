using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanonInteract : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float interactDistance = 2f;
    [SerializeField] private LayerMask interactLayer;
    [SerializeField] private TMP_Text message;

    public MouseLook mainCameraMove;
    public CanonLook canonLook;
    public PlayerMovement move;
    public Camera firstPersonCamera;
    public Camera canonCamera;
    public void Start()
    {
        canonCamera.enabled = false;
        firstPersonCamera.enabled = true;
        canonLook.enabled = false;
    }

    void Update()
    {

        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit raycastHit, interactDistance, interactLayer))
        {

            // Pointing towards an item
            if (raycastHit.transform.CompareTag("Canon") && !canonCamera.enabled)
            {
                message.SetText("Press `E` to use.");
                message.gameObject.SetActive(true);


                if (Input.GetKeyDown(KeyCode.E))
                {
                    // change camera to canon camera
                    firstPersonCamera.enabled = false;
                    canonCamera.enabled = true;
                    canonLook.enabled = true;
                    move.enabled = false;
                    mainCameraMove.enabled = false;
                }

                // Pointing towards a multimeter
            }
            else
            {
                message.gameObject.SetActive(false);
            }
        }
        else
        {
            message.gameObject.SetActive(false);
        }
        // close switch back to first person
        if (Input.GetKeyDown(KeyCode.Escape) && canonCamera.enabled)
        {
            canonCamera.enabled = false;
            canonLook.enabled = false;
            firstPersonCamera.enabled = true;
            move.enabled = true;
            mainCameraMove.enabled = true;
        }
    }

}
