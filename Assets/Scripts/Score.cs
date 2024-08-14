using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    public TextMeshProUGUI text;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Current\nScore: " + score;
        //Test();
    }

    void AddPoints(int points)
    {
        score += points;
    }

    void RemovePoints(int points)
    {
        score -= points;
    }

    private void Test()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            AddPoints(10);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            RemovePoints(10);
        }
    }
}
