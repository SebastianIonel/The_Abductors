using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetClickRaycaster : MonoBehaviour
{
    private PlanetClickHandler selectedPlanet;

    void Start() {
        Cursor.lockState = CursorLockMode.None;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                PlanetClickHandler planet = hit.collider.GetComponent<PlanetClickHandler>();
                if (planet != null)
                {
                    if (selectedPlanet != planet) {
                        if (selectedPlanet != null) {
                            selectedPlanet.OnPlanetChanged();
                        }
                        selectedPlanet = planet;
                        selectedPlanet.OnPlanetClicked();
                    }
                }
            }
        }
    }
}

