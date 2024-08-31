using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SceneChanger : MonoBehaviour
{
    public string sceneName;
    public float changeTime;

    private void Update()
    {
        changeTime -= Time.deltaTime;
        if(changeTime <= 0) {
            SceneManager.LoadScene(sceneName);
        }
    }
}
