using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class QuizManager : MonoBehaviour
{
    public TMP_Text questionText; 
    public Button[] answerButtons;

    private string correctAnswer;

    public MouseLook mouseLook;

    private void Start() {
        gameObject.SetActive(false);
    } 
    public void StartQuiz(string organName)
    {
        gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        mouseLook.enabled = false;

        switch (organName)
        {
            case "Heart":
                SetQuiz("What is the primary function of the heart?", "Pump blood", "Oxygenate blood", "Filter blood", "Store blood", "Pump blood");
                break;
            case "Brain":
                SetQuiz("What is the primary function of the lungs?", "Pump blood", "Oxygenate blood", "Filter blood", "Store blood", "Oxygenate blood");
                break;
            case "Brain":
                SetQuiz("How many lobes are in the cerebral cortex?", "Two", "Three", "Four", "Five");
                break;
            case "Eye":
                SetQuiz("What is the main purpose of the pupil?", "Shrinks or grows to allow light into your eye", "Send electrical signals to your brain.", "Block bugs from getting to your brain.", "A black hole to dump garbage in.");
                break;
            default:
                Debug.LogWarning("Unknown organ name: " + organName);
                break;
        }
    }

    private void SetQuiz(string question, string option1, string option2, string option3, string option4, string correctAnswer)
    {
        questionText.text = question;
        answerButtons[0].GetComponentInChildren<TMP_Text>().text = option1;
        answerButtons[1].GetComponentInChildren<TMP_Text>().text = option2;
        answerButtons[2].GetComponentInChildren<TMP_Text>().text = option3;
        answerButtons[3].GetComponentInChildren<TMP_Text>().text = option4;
        this.correctAnswer = correctAnswer;

        // Adăugarea funcționalității la butoane
        for (int i = 0; i < answerButtons.Length; i++)
        {
            int index = i; // Pentru a evita problemele cu closure
            answerButtons[i].onClick.AddListener(() => CheckAnswer(answerButtons[index].GetComponentInChildren<TMP_Text>().text));
        }
    }

    private void CheckAnswer(string answer)
    {
        if (answer == correctAnswer)
        {
            Debug.Log("Correct answer!");
        }
        else
        {
            Debug.Log("Incorrect answer.");
        }

        // Ascunde panelul după ce s-a dat răspunsul
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        mouseLook.enabled = true;
    }
}
