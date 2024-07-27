using UnityEngine;
using TMPro;

public class Multimeter : MonoBehaviour
{
    public TMP_Text displayText; // Asociaza acest text in Inspector
    private float measuredResistance;

    // Metoda pentru simularea masurarii rezistentei
    public void MeasureResistance(GameObject resistanceObject)
    {
        Resistance resistance = resistanceObject.GetComponent<Resistance>();
        if (resistance != null) {
            measuredResistance = resistance.resistanceValue;
            UpdateDisplay();
        }
    }

    // Actualizeaza textul afisat cu valoarea masurata a rezistentei
    void UpdateDisplay()
    {
        displayText.text = "Measured Resistance: " + measuredResistance + " Ohms";
    }
}