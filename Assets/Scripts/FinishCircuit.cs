using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCircuit : MonoBehaviour
{
    public int resistanceValue = 100;

    public void Repair(GameObject resistanceObject)
    {
        if (resistanceObject != null) {
            Resistance resistance = resistanceObject.GetComponent<Resistance>();
            if (resistance != null) {
                if (resistance.resistanceValue == resistanceValue) {
                    Debug.Log("Congrats!!");
                    Destroy(gameObject);
                } else {
                    Debug.Log("Shit!");
                }
            }
        }
    }
}