using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private GameObject asteroids;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private TMP_Text endMessage;
    [SerializeField] private TMP_Text gunMessage;
    [SerializeField] private Score score;
    bool endScreenOn = false;

    void Start() {
        endScreen.SetActive(false);
    }

    void Update()
    {
        bool end = true;
        AsteroidData[] asteroidDatas = asteroids.GetComponentsInChildren<AsteroidData>();
        foreach (AsteroidData asteroidData in asteroidDatas) {
            if (!asteroidData.marked) {
                end = false;
                break;
            }
        }
        if (end && !endScreenOn) {
            endMessage.SetText("<color=#a73f04>Score</color>\n" + score.score + '/' + score.maxScore + "\n\n");
            if (score.score <= 0) {
                endMessage.text += "Planeta Chimie are de suferit daune mari. Vietuitoarele vor avea mult de luptat pentru a supravietuii...";
            } else if (score.score < score.maxScore / 2) {
                endMessage.text += "Planeta Chimie are de suferit daune medii. Vietuitoarele vor avea un timp greu, dar vor supravietuii...";
            } else if (score.score < score.maxScore) {
                endMessage.text += "Planeta Chimie are de suferit daune minime. Vietuitoarele se vor bucura de noile resurse si isi vor continua stilul de viata nemodificat...";
            } else {
                endMessage.text += "Planeta Chimie nu are de suferit daune. Vietuitoarele vor prospera, iar dezvoltarea lor va fi accelerata!";
            }
            endScreen.SetActive(true);
            gunMessage.gameObject.SetActive(false);
            endScreenOn = true;
        }
        if (!endScreen) {
            SceneManager.LoadScene("Menu");
        }
    }
}
