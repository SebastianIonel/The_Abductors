using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class PlanetClickRaycaster : MonoBehaviour
//{
    // Start is called before the first frame update
  //  void Start()
    //{
        
    //}

    // Update is called once per frame
    //void Update()
    //{
        
    //}
//}


//using UnityEngine;

public class PlanetClickRaycaster : MonoBehaviour
{
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
                    planet.OnPlanetClicked();
                }
            }
        }
    }
}

