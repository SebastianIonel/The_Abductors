using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidData : MonoBehaviour
{
    public string[] substances; // MAX 4 SUBSTANCES!!
    public float[] percentages; // In order with the substances!!!
    public int type; // 1/2/3/..
    public int points;
    public bool marked = false;
    public Material highlightMat;
    public Material asteroidMat;
    public MeshRenderer[] meshRenderers;

    void Start()
    {
        if (PlayerPrefs.HasKey(gameObject.name + "Destroyed") && PlayerPrefs.GetInt(gameObject.name + "Destroyed") == 1) {
            Destroy(gameObject);
        }
        if (PlayerPrefs.HasKey(gameObject.name + "Marked") && PlayerPrefs.GetInt(gameObject.name + "Marked") == 1) {
            marked = true;
        }
    }

    void Update() {
        if (marked) {
            foreach (MeshRenderer meshRenderer in meshRenderers) {
                meshRenderer.SetMaterials(new List<Material>{asteroidMat, highlightMat});
            }
        } else {
            foreach (MeshRenderer meshRenderer in meshRenderers) {
                meshRenderer.SetMaterials(new List<Material>{asteroidMat, null});
            }
        }
    }
}
