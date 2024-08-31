using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelB : MonoBehaviour
{
    private bool finish = false;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private QuizManager quizManager;

    private void Start()
    {
        endScreen.SetActive(false);
    }

    private void Update()
    {
        if (!endScreen) {
            SceneManager.LoadScene("Menu");
        }
        if (!quizManager.quizHeart && !quizManager.quizBrain && !quizManager.quizEye && !finish) {
            endScreen.SetActive(true);
            finish = true;
        }
    }
}
