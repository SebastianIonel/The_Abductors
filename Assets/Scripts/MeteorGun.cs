using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorGun : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private float laserWidth = 0.05f;
    [SerializeField] private float laserDuration = 3.0f;

    void Start()
    {
        lineRenderer = GetComponentInChildren<LineRenderer>();
        
        lineRenderer.startWidth = laserWidth;
        lineRenderer.endWidth = laserWidth;
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
    }

    void Shoot(bool destroy, Vector3 startPos, Vector3 endPos)
    {
        if (destroy) {

        } else {
            lineRenderer.startColor = Color.green;
            lineRenderer.endColor = Color.green;
            StartCoroutine(FireLaser(startPos, endPos));
        }
    }

    private IEnumerator FireLaser(Vector3 startPos, Vector3 endPos)
    {
        lineRenderer.enabled = true;

        // Set the positions of the line renderer
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);

        // Wait for the laser duration
        yield return new WaitForSeconds(laserDuration);

        // Disable the laser
        lineRenderer.enabled = false;
    }
}
