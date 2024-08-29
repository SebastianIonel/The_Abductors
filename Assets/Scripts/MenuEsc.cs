using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuEsc : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;

    private MenuManager menuManager;

    void Start()
    {
        menuManager = menuPanel.GetComponent<MenuManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            menuPanel.SetActive(true);
            menuManager.StartMenu();
        }
    }
}
