using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using Unity.VisualScripting;
using System.Collections;

public class QuizManager : MonoBehaviour
{
    public TMP_Text questionText; 
    public Button[] answerButtons;

    private string correctAnswer;

    public MouseLook mouseLook;
    public Transform[] organs;
    public Transform[] organsPositions;
    public Vector3[] organsScales;
    private int type;
    private int idx;
    private bool quizHeart = true;
    private bool quizBrain = true;
    private bool quizEye = true;

    private void Start() {
        // Adăugarea funcționalității la butoane
        for (int i = 0; i < answerButtons.Length; i++)
        {
            int index = i; // Pentru a evita problemele cu closure
            answerButtons[i].onClick.AddListener(() => CheckAnswer(answerButtons[index].GetComponentInChildren<TMP_Text>().text));
        }

        if (PlayerPrefs.GetInt("HeartSolved") == 1) {
            organs[0].position = organsPositions[0].position;
            organs[0].localScale = organsScales[0];
            organs[0].tag = "Untagged";
            quizHeart = false;
        }
        if (PlayerPrefs.GetInt("BrainSolved") == 1) {
            organs[1].position = organsPositions[1].position;
            organs[1].localScale = organsScales[1];
            organs[1].tag = "Untagged";
            quizBrain = false;
        }
        if (PlayerPrefs.GetInt("EyeSolved") == 1) {
            organs[2].position = organsPositions[2].position;
            organs[2].localScale = organsScales[2];
            organs[2].tag = "Untagged";
            quizEye = false;
        }

        gameObject.SetActive(false);
    } 
    public void StartQuiz(string organName)
    {
        gameObject.SetActive(true);
        correctAnswer = null;
        Cursor.lockState = CursorLockMode.None;
        mouseLook.enabled = false;
        idx = 0;

        switch (organName)
        {
            case "Heart":
                type = 0;
                break;
            case "Brain":
                type = 1;
                break;
            case "Eye":
                type = 2;
                break;
            default:
                Debug.LogWarning("Unknown organ name: " + organName);
                break;
        }
        if (type == 0 && quizHeart || type == 1 && quizBrain || type == 2 && quizEye) {
            Question(type, idx);
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
    }

    public void CheckAnswer(string answer)
    {
        if (answer == correctAnswer)
        {
            Debug.Log("Correct answer!");
            if (!Question(type, ++idx)) {
                StartCoroutine(DisableButtons());
                return;
            }
            organs[type].position = organsPositions[type].position;
            organs[type].localScale = organsScales[type];
            organs[type].tag = "Untagged";
            if (type == 0) {
                quizHeart = false;
                PlayerPrefs.SetInt("HeartSolved", 1);
            } else if (type == 1) {
                quizBrain = false;
                PlayerPrefs.SetInt("BrainSolved", 1);
            } else {
                quizEye = false;
                PlayerPrefs.SetInt("EyeSolved", 1);
            }
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

    private bool Question(int type, int idx) {
        switch (type) {
            case 0: {  // Heart
                switch (idx) {
                    case 0: {
                        SetQuiz("What is the primary function of the heart?", "Pump blood", "Oxygenate blood", "Filter blood", "Store blood", "Pump blood");
                        break;
                    }
                    case 1: {
                        SetQuiz("How many chambers does the human heart have?", "Two", "Four", "Six", "Eight", "Four");
                        break;
                    }
                    case 2: {
                        SetQuiz("What is the muscular layer of the heart called?", "Epidermis", "Pericardium", "Myocardium", "Endocardium", "Myocardium");
                        break;
                    }
                    default: {
                        return true;
                    }
                }
                break;
            }
            case 1: {  // Brain
                switch (idx) {
                    case 0: {
                        SetQuiz("How many lobes are in the cerebral cortex?", "Two", "Three", "Four", "Five", "Four");
                        break;
                    }
                    case 1: {
                        SetQuiz("What is the largest part of the human brain?", "Cerebellum", "Brainstem", "Cerebrum", "Thalamus", "Cerebrum");
                        break;
                    }
                    case 2: {
                        SetQuiz("Which part of the brain is responsible for coordinating balance and movement?", "Cerebrum", "Medulla", "Pons", "Cerebellum", "Cerebellum");
                        break;
                    }
                    default: {
                        return true;
                    }
                }
                break;
            }
            case 2: {  // Eye
                switch (idx) {
                    case 0: {
                        SetQuiz("What is the main purpose of the pupil?", "Shrinks or grows to allow light into your eye", "Send electrical signals to your brain.", "Block bugs from getting to your brain.", "A black hole to dump garbage in.", "Shrinks or grows to allow light into your eye");
                        break;
                    }
                    case 1: {
                        SetQuiz("What is the colored part of the eye that controls the size of the pupil?", "Retina", "Lens", "Iris", "Cornea", "Iris");
                        break;
                    }
                    case 2: {
                        SetQuiz("What is the transparent, outermost layer of the eye that helps to protect it?", "Cornea", "Retina", "Pupil", "Sclera", "Cornea");
                        break;
                    }
                    default: {
                        return true;
                    }
                }
                break;
            }
        }
        return false;
    }

    private IEnumerator DisableButtons()
    {
        for (int i = 0; i < answerButtons.Length; i++) {
            answerButtons[i].interactable = false;
        }

        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < answerButtons.Length; i++) {
            answerButtons[i].interactable = true;
        }
    }
}
