using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectClickHandler : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject asteroidUIPrefab;

    private GameObject asteroidUIInstance;
    private GameObject selectedObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject.tag == "Asteroid") 
                {
                    selectedObject = hit.collider.gameObject;
                    ShowAsteroidUI(selectedObject); 
                }
            }
        }
    }

    void ShowAsteroidUI(GameObject asteroid)
    {
        if (asteroidUIInstance != null)
        {
            Destroy(asteroidUIInstance);
        }

        asteroidUIInstance = Instantiate(asteroidUIPrefab);
        asteroidUIInstance.transform.SetParent(GameObject.Find("Canvas").transform, false);

    
        TextMeshProUGUI infoText1 = asteroidUIInstance.transform.Find("InfoText1").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI infoText2 = asteroidUIInstance.transform.Find("InfoText2").GetComponent<TextMeshProUGUI>();
        infoText1.text = "Asteroid Name: " + asteroid.name;
        infoText2.text = "Asteroid Position: " + asteroid.transform.position.ToString();


        Button destroyButton = asteroidUIInstance.transform.Find("DestroyButton").GetComponent<Button>();
        Button cancelButton = asteroidUIInstance.transform.Find("CancelButton").GetComponent<Button>();
        destroyButton.onClick.AddListener(DestroySelectedAsteroid);
        cancelButton.onClick.AddListener(CancelSelection);
    }

    void DestroySelectedAsteroid()
    {
        if (selectedObject != null)
        {
            Destroy(selectedObject);
            Destroy(asteroidUIInstance); 
        }
    }

    void CancelSelection()
    {
        if (asteroidUIInstance != null)
        {
            Destroy(asteroidUIInstance); 
        }
        selectedObject = null;
    }
}

