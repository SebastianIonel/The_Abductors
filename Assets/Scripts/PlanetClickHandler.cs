using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetClickHandler : MonoBehaviour
{
    // Start is called before the first frame update

    // public GameObject planetMenu;
    //private void OnMouseDown()
    //{
    //  planetMenu.SetActive(true);
    //}
    public GameObject planetMenu;

    public void OnPlanetClicked()
    {
        Debug.Log("Planet clicked: " + gameObject.name);
        planetMenu.SetActive(true);
    }
}
