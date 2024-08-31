using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public bool canMove = true;
    public int level;

    // Car movement
    public bool isCar = false;

    void Start()
    {
        controller.enabled = false;
        switch (level) {
            case 0: {
                if (isCar) {
                    if (PlayerPrefs.HasKey("FizicaCarPosX")) {
                        transform.position = new Vector3(PlayerPrefs.GetFloat("FizicaCarPosX"), PlayerPrefs.GetFloat("FizicaCarPosY"), PlayerPrefs.GetFloat("FizicaCarPosZ"));
                        transform.eulerAngles = new Vector3(PlayerPrefs.GetFloat("FizicaCarRotationX"), PlayerPrefs.GetFloat("FizicaCarRotationY"), PlayerPrefs.GetFloat("FizicaCarRotationZ"));
                    }
                } else {
                    if (PlayerPrefs.HasKey("FizicaPlayerPosX")) {
                        transform.position = new Vector3(PlayerPrefs.GetFloat("FizicaPlayerPosX"), PlayerPrefs.GetFloat("FizicaPlayerPosY"), PlayerPrefs.GetFloat("FizicaPlayerPosZ"));
                        transform.eulerAngles = new Vector3(PlayerPrefs.GetFloat("FizicaPlayerRotationX"), PlayerPrefs.GetFloat("FizicaPlayerRotationY"), PlayerPrefs.GetFloat("FizicaPlayerRotationZ"));
                    }
                }
                break;
            }
            case 1: {
                if (PlayerPrefs.HasKey("ChimiePlayerPosX")) {
                    transform.position = new Vector3(PlayerPrefs.GetFloat("ChimiePlayerPosX"), PlayerPrefs.GetFloat("ChimiePlayerPosY"), PlayerPrefs.GetFloat("ChimiePlayerPosZ"));
                    transform.eulerAngles = new Vector3(PlayerPrefs.GetFloat("ChimiePlayerRotationX"), PlayerPrefs.GetFloat("ChimiePlayerRotationY"), PlayerPrefs.GetFloat("ChimiePlayerRotationZ"));
                }
                break;
            }
            case 2: {
                if (PlayerPrefs.HasKey("BioPlayerPosX")) {
                    transform.position = new Vector3(PlayerPrefs.GetFloat("BioPlayerPosX"), PlayerPrefs.GetFloat("BioPlayerPosY"), PlayerPrefs.GetFloat("BioPlayerPosZ"));
                    transform.eulerAngles = new Vector3(PlayerPrefs.GetFloat("BioPlayerRotationX"), PlayerPrefs.GetFloat("BioPlayerRotationY"), PlayerPrefs.GetFloat("BioPlayerRotationZ"));
                }
                break;
            }
        }
        controller.enabled = true;
    }

    void Update()
    {
        if (canMove) {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0f) {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = Vector3.zero;
            if (!isCar) {
                move = transform.right * x;
            }
            move += transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            // Jump
            if (!isCar && Input.GetButtonDown("Jump") && isGrounded) {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
    }
}
