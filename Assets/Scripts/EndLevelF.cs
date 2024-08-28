using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelF : MonoBehaviour
{

    public ShipComponent circuit0;
    public ShipComponent circuit1;
    public ShipComponent circuit2;
    private int counter = 180;

    public TextMeshProUGUI endText;

    // Start is called before the first frame update
    void Start()
    {
        endText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (circuit0 == null && circuit1 == null && circuit2 == null)
        {
            endText.enabled = true;
            counter--;
        }

        if (counter < 1)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
