using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCircuit : MonoBehaviour
{
    public int resistanceValue = 100;

    public bool Repair(GameObject resistanceObject)
    {
        if (resistanceObject != null) {
            Resistance resistance = resistanceObject.GetComponent<Resistance>();
            if (resistance != null) {
                if (resistance.resistanceValue == resistanceValue) {
                    Debug.Log("Congrats!!");
                    return true;
                } else {
                    Debug.Log("Shit!");
                    return false;
                }
            }
        }
        return false;
    }
}
