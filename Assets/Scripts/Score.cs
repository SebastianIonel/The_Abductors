using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    public TextMeshProUGUI text;
    public int score;
    public int maxScore;
    [SerializeField] private GameObject asteroids;

    void Start()
    {
        if (PlayerPrefs.HasKey("ScoreChimie")) {
            score = PlayerPrefs.GetInt("ScoreChimie");
        } else {
            score = 0;
        }
        AsteroidData[] asteroidDatas = asteroids.GetComponentsInChildren<AsteroidData>();
        foreach (AsteroidData asteroidData in asteroidDatas) {
            score += asteroidData.points;
        }
    }

    void Update()
    {
        text.text = "Score: " + score;
    }

    public void AddPoints(int points)
    {
        score -= points;
    }
}
