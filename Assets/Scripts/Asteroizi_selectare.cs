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
    private GameObject displayAsteroid;
    [SerializeField] private Transform center;
    [SerializeField] private GameObject[] asteroids; // Asteroid prefabs in order
    [SerializeField] private GameObject[] arrows; // Arrows in order
    [SerializeField] private TMP_Text[] arrow_texts; // Arrow texts in order
    [SerializeField] private MeteorGun meteorGun;

    void Start()
    {
        foreach (GameObject arrow in arrows) {
            arrow.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                AsteroidData asteroidData = hit.collider.GetComponent<AsteroidData>();
                if (asteroidData != null && hit.collider.CompareTag("Asteroid"))
                {
                    selectedObject = hit.collider.gameObject;
                    ShowAsteroidUI(selectedObject, asteroidData);
                }
            }
        }
    }

    void ShowAsteroidUI(GameObject asteroid, AsteroidData asteroidData)
    {
        if (asteroidData.type == 0) {
            Debug.Log("Invalid asteroid");
            return;
        }
        if (displayAsteroid != null) {
            Destroy(displayAsteroid);
            foreach (GameObject arrow in arrows) {
                arrow.SetActive(false);
            }
        }
        displayAsteroid = Instantiate(asteroids[asteroidData.type - 1], center);
        
        for (int i = 0; i < asteroidData.substances.Length; i++) {
            arrows[i].SetActive(true);
            arrow_texts[i].SetText(asteroidData.substances[i]);
        }
        
        // TextMeshProUGUI infoText1 = asteroidUIInstance.transform.Find("InfoText1").GetComponent<TextMeshProUGUI>();
        // TextMeshProUGUI infoText2 = asteroidUIInstance.transform.Find("InfoText2").GetComponent<TextMeshProUGUI>();
        // infoText1.text = "Asteroid Name: " + asteroid.name;
        // infoText2.text = "Asteroid Position: " + asteroid.transform.position.ToString();


        // Button destroyButton = asteroidUIInstance.transform.Find("DestroyButton").GetComponent<Button>();
        // Button cancelButton = asteroidUIInstance.transform.Find("CancelButton").GetComponent<Button>();
        // destroyButton.onClick.AddListener(DestroySelectedAsteroid);
        // cancelButton.onClick.AddListener(CancelSelection);
    }

    // void DestroySelectedAsteroid()
    // {
    //     if (selectedObject != null)
    //     {
    //         Destroy(selectedObject);
    //         Destroy(asteroidUIInstance); 
    //     }
    // }

    // void CancelSelection()
    // {
    //     if (asteroidUIInstance != null)
    //     {
    //         Destroy(asteroidUIInstance); 
    //     }
    //     selectedObject = null;
    // }
}

