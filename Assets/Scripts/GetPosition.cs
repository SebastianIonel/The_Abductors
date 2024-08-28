using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPosition : MonoBehaviour
{

    private Vector3 objectPosition;

    void Start()
    {
        objectPosition = transform.position;
    }

    void Update()
    {
        objectPosition = transform.position;
    }

    public Vector3 GetPos()
    {
        return objectPosition;
    } 
}
