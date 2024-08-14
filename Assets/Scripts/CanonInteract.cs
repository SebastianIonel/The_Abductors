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
    public ObjectClickHandler selectAsteroid;

    public bool scan = true;

    public void Start()
    {
        canonCamera.enabled = false;
        firstPersonCamera.enabled = true;
        canonLook.enabled = false;
    }

    void Update()
    {
        if (!canonCamera.enabled) {
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit raycastHit, interactDistance, interactLayer))
            {

                // Pointing towards an item
                if (raycastHit.transform.CompareTag("Canon")) {
                    message.SetText("Press `E` to use.");
                    message.gameObject.SetActive(true);


                    if (Input.GetKeyDown(KeyCode.E)) {
                        // change camera to canon camera
                        firstPersonCamera.enabled = false;
                        canonCamera.enabled = true;
                        canonLook.enabled = true;
                        move.enabled = false;
                        mainCameraMove.enabled = false;
                        selectAsteroid.usingGun = true;
                        message.SetText("Press `E` to switch mode.\nMode: <color=#00FF00>Scan</color>");
                    }
                } else {
                    message.gameObject.SetActive(false);
                }
            } else {
                message.gameObject.SetActive(false);
            }
        } else {
            // close switch back to first person
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                canonCamera.enabled = false;
                canonLook.enabled = false;
                firstPersonCamera.enabled = true;
                move.enabled = true;
                mainCameraMove.enabled = true;
                selectAsteroid.usingGun = false;
                scan = true;
            } else if (Input.GetKeyDown(KeyCode.E)) {
                scan = !scan;
                if (scan) {
                    message.SetText("Press `E` to switch mode.\nMode: <color=#00FF00>Scan</color>");
                } else {
                    message.SetText("Press `E` to switch mode.\nMode: <color=#FF0000>Destroy</color>");
                }
            }
        }
    }
}
