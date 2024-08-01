using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetClickHandler : MonoBehaviour
{
    public GameObject planetMenu;

    public void OnPlanetClicked()
    {
        planetMenu.SetActive(true);
    }
    public void OnPlanetChanged()
    {
        planetMenu.SetActive(false);
    }
}
