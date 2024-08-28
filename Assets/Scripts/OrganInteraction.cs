using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrganInteraction : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float interactDistance = 2f;
    [SerializeField] private LayerMask interactLayer;
    [SerializeField] private TMP_Text message;
    [SerializeField] private GameObject quizPanel;
    
    private QuizManager quizManager;

    void Start()
    {
        quizManager = quizPanel.GetComponent<QuizManager>();
    }

    void Update()
    {
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit raycastHit, interactDistance, interactLayer))
        {
            if (raycastHit.transform.CompareTag("Organ"))
            {
                message.SetText("Press `E` to interact.");
                message.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    quizPanel.SetActive(true);
                    quizManager.StartQuiz(raycastHit.transform.gameObject.name);
                }
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
    }
}
