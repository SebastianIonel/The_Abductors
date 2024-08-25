using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnKeyPressed : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) {
            Destroy(gameObject);
        }
    }
}
