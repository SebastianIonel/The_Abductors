using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public void StartQuiz(string organName)
    {
        // Aici ar trebui să adaugi logica pentru a începe un quiz, în funcție de organul selectat.
        Debug.Log("Quiz started for organ: " + organName);

        // Exemple de întrebări în funcție de organ:
        if (organName == "Heart")
        {
            // Logică pentru întrebările despre inimă
        }
        else if (organName == "Lung")
        {
            // Logică pentru întrebările despre plămâni
        }
    }
}
