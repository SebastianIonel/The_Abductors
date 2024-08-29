using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuEsc : MonoBehaviour
{
    [SerializeField] private GameObject quizPanel;

    private MenuManager quizManager;

    void Start()
    {
        quizManager = quizPanel.GetComponent<MenuManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            quizPanel.SetActive(true);
            quizManager.StartQuiz();
        }
    }
}
