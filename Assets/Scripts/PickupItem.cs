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
    [SerializeField] private FinishCircuit circuit;
    [SerializeField] private Transform meteorGun;
    [SerializeField] private Transform cameraAnchor;

    public GameObject currentItem;
    public SpriteChangerInventory spriteChanger;
    public SpriteChangerShip spriteChangerShip;

    /*
     * level 0 = fizica
     * level 1 = chimie
     * level 2 = biologie
    */
    public int level = 0;
    private Vector3 cameraPos;
    private MouseLook mouseLook;
    private PlayerMovement playerMovement;

    void Awake()
    {
        cameraPos = Camera.main.transform.localPosition;
        mouseLook = GetComponentInChildren<MouseLook>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (!mouseLook.usingGun) {
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit raycastHit, interactDistance, interactLayer)) {

                switch (level) {
                    case 0: {
                        // Pointing towards an item
                        if (raycastHit.transform.CompareTag("Item")) {
                            message.SetText("Press `E` to pick up item.");
                            message.gameObject.SetActive(true);
                            

                            if (Input.GetKeyDown(KeyCode.E)) {
                                currentItem = raycastHit.transform.gameObject;
                                spriteChanger.ChangeSprite(currentItem);
                            }
                        
                        // Pointing towards a multimeter
                        } else if (raycastHit.transform.CompareTag("Multimeter")) {
                            message.SetText("Press `E` to measure resistance value.");
                            message.gameObject.SetActive(true);

                            if (currentItem != null && Input.GetKeyDown(KeyCode.E)) {
                                raycastHit.transform.GetComponent<Multimeter>().MeasureResistance(currentItem);
                            }
                        
                        // Pointing towards the spaceship
                        } else if (raycastHit.transform.CompareTag("Circuit")) {
                            if (currentItem == null) {
                                message.SetText("Something is missing.");
                                if (Input.GetKeyDown(KeyCode.E))
                                {
                                    // add changer ship
                                    spriteChangerShip.DisplayPuzzle();
                                }
                            } else {
                                message.SetText("Press `E` to repair the Spaceship.");
                            }
                            message.gameObject.SetActive(true);

                            if (Input.GetKeyDown(KeyCode.E)) {
                                circuit.Repair(currentItem);
                                spriteChanger.Reset();
                                currentItem = null;
                            }
                        } else {
                            message.gameObject.SetActive(false);
                        }
                        break; 
                    }
                    case 1: {
                        if (raycastHit.transform.CompareTag("MeteorGun")) {
                            message.SetText("Press `E` to use the MeteorDestroyer3700.");
                            message.gameObject.SetActive(true);

                            if (Input.GetKeyDown(KeyCode.E)) {
                                UseWeapon();
                            }
                        } else {
                            message.gameObject.SetActive(false);
                        }
                        break;
                    }
                }
            } else {
                message.gameObject.SetActive(false);
            }
        } else {
            if (Input.GetKeyDown(KeyCode.E)) {
                StopUsingWeapon();
            }
        }
        
        // close puzzle
        if (level == 0 && Input.GetKeyDown(KeyCode.Escape) && spriteChangerShip.IsPuzzleActive())
        {
            spriteChangerShip.HidePuzzle();
        }
    }

    void UseWeapon()
    {
        mouseLook.playerBody = meteorGun;
        mouseLook.usingGun = true;

        playerMovement.canMove = false;

        Camera.main.transform.SetParent(cameraAnchor);
        Camera.main.transform.localPosition = Vector3.zero;
        Camera.main.transform.localRotation = Quaternion.identity;

        message.SetText("Press `E` to go back.");
        message.gameObject.SetActive(true);
    }
    void StopUsingWeapon()
    {
        mouseLook.playerBody = transform;
        mouseLook.usingGun = false;

        playerMovement.canMove = true;

        Camera.main.transform.SetParent(transform);
        Camera.main.transform.localPosition = cameraPos;
        Camera.main.transform.localRotation = Quaternion.identity;
    }
}
