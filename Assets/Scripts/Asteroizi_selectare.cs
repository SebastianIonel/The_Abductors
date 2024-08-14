using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ObjectClickHandler : MonoBehaviour
{
    public Camera mainCamera;
    private GameObject selectedObject;
    public GameObject displayAsteroid;
    [SerializeField] private Transform center;
    [SerializeField] private GameObject[] asteroids; // Asteroid prefabs in order
    [SerializeField] private GameObject[] arrows; // Arrows in order
    [SerializeField] private TMP_Text[] arrow_texts; // Arrow texts in order
    [SerializeField] private MeteorGun meteorGun;
    [SerializeField] private CanonInteract canonInteract;

    public bool usingGun;

    void Start()
    {
        foreach (GameObject arrow in arrows) {
            arrow.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && usingGun)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                AsteroidData asteroidData = hit.collider.GetComponent<AsteroidData>();
                if (asteroidData != null && hit.collider.CompareTag("Asteroid"))
                {
                    selectedObject = hit.collider.gameObject;

                    if (canonInteract.scan) {
                        ShowAsteroidUI(asteroidData);
                    }
                    meteorGun.Shoot(canonInteract.scan, hit.distance, selectedObject);
                }
            }
        }
    }

    void ShowAsteroidUI(AsteroidData asteroidData)
    {
        if (asteroidData.type == 0) {
            Debug.Log("Invalid asteroid");
            return;
        }
        HideAsteroidUI();
        displayAsteroid = Instantiate(asteroids[asteroidData.type - 1], center);
        
        for (int i = 0; i < asteroidData.substances.Length; i++) {
            arrows[i].SetActive(true);
            arrow_texts[i].SetText(asteroidData.substances[i]);
        }
    }

    public void HideAsteroidUI()
    {
        if (displayAsteroid != null) {
            Destroy(displayAsteroid);
            foreach (GameObject arrow in arrows) {
                arrow.SetActive(false);
            }
        }
    }
}

