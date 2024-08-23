using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipComponent : MonoBehaviour
{
    public float result;
    public UnityEngine.UI.Image puzzle;

    public bool Repair(GameObject resistanceObject)
    {
        if (resistanceObject != null)
        {
            Resistance resistance = resistanceObject.GetComponent<Resistance>();
            if (resistance != null)
            {
                if (resistance.resistanceValue == result)
                {
                    Debug.Log("Congrats!!");
                    return true;
                }
                else
                {
                    Debug.Log("Shit!");
                    return false;
                }
            }
        }
        return false;
    }
}