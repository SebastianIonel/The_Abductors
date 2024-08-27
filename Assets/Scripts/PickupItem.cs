using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine.UI;

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
    private GameObject shipComponentObj;
    private ShipComponent shipComponent;
    /*
     * level 0 = fizica
     * level 1 = chimie
     * level 2 = biologie
    */
    public int level = 0;
    private Vector3 cameraPos;
    private MouseLook mouseLook;
    private PlayerMovement playerMovement;
    
    // Car interaction variables
    [SerializeField] private Camera firstPersonCamera;
    [SerializeField] private Camera carCamera;
    [SerializeField] private AudioListener firstPersonListener;
    [SerializeField] private AudioListener carListener;
    public MouseLook mainCameraMove;
    public CarLook carLook;
    public PlayerMovement move;
    [SerializeField] private bool usingCar = false;
    [SerializeField] private PlayerMovement carMovement;
    [SerializeField] private Transform playerSpot;
    private CharacterController characterController;

    void Awake()
    {
        cameraPos = Camera.main.transform.localPosition;
        mouseLook = GetComponentInChildren<MouseLook>();
        playerMovement = GetComponent<PlayerMovement>();
        characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        carCamera.enabled = false;
        firstPersonCamera.enabled = true;
        carLook.enabled = false;
        carMovement.enabled = false;
        firstPersonListener.enabled = true;
        carListener.enabled = false;
    }

    void Update()
    {
        // open map
        if (Input.GetKeyDown(KeyCode.M))
        {
            spriteChanger.Map();

        }

        if (!usingCar) {
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit raycastHit, interactDistance, interactLayer)) {

                switch (level) {
                    case 0: {  // Fizica
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
                            shipComponentObj = raycastHit.transform.gameObject;
                            shipComponent = shipComponentObj.GetComponent<ShipComponent>();
                                
                            if (currentItem == null) {
                                message.SetText("Something is missing.");
                                if (Input.GetKeyDown(KeyCode.E))
                                {
                                    
                                    spriteChangerShip.SetPuzzle(shipComponent.puzzle);
                                    // add changer ship
                                    spriteChangerShip.DisplayPuzzle();
                                    
                                    }
                            } else {
                                message.SetText("Press `E` to repair the Spaceship.");
                            }
                            message.gameObject.SetActive(true);

                            if (Input.GetKeyDown(KeyCode.E)) {
                                if (shipComponent.Repair(currentItem))
                                {
                                    Destroy(raycastHit.collider.gameObject);
                                    spriteChanger.Reset();
                                    currentItem = null;
                                }
                            }
                        } else if (raycastHit.transform.CompareTag("Car")) {
                            message.SetText("Press `E` to enter the car.");
                            message.gameObject.SetActive(true);
                            
                            if (Input.GetKeyDown(KeyCode.E)) {
                                firstPersonCamera.enabled = false;
                                carCamera.enabled = true;
                                carLook.enabled = true;
                                move.enabled = false;
                                mainCameraMove.enabled = false;
                                carMovement.enabled = true;
                                firstPersonListener.enabled = false;
                                carListener.enabled = true;
                                usingCar = true;

                                characterController.enabled = false;
                                transform.SetParent(playerSpot);
                                transform.localPosition = Vector3.zero;

                                message.SetText("Press `E` to exit the car.");
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
                firstPersonCamera.enabled = true;
                carCamera.enabled = false;
                carLook.enabled = false;
                move.enabled = true;
                mainCameraMove.enabled = true;
                carMovement.enabled = false;
                firstPersonListener.enabled = true;
                carListener.enabled = false;
                usingCar = false;
                characterController.enabled = true;
                transform.SetParent(null);
            }
            // TODO: Zona sa verific daca pot sa ma dau jos din masina
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

        playerMovement.canMove = true;

        Camera.main.transform.SetParent(transform);
        Camera.main.transform.localPosition = cameraPos;
        Camera.main.transform.localRotation = Quaternion.identity;
    }
    public void DropItem()
    {
        spriteChanger.Reset();
        currentItem = null;
    }
}
