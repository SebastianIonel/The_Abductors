using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public Button[] answerButtons;

    public MouseLook mouseLook;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void StartMenu()
    {
        gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        mouseLook.enabled = false;


        SetMenu( "Resume", "Main Menu", "Quit");

    }

    private void SetMenu(string option1, string option2, string option3)
    {
        answerButtons[0].GetComponentInChildren<TMP_Text>().text = option1;
        answerButtons[1].GetComponentInChildren<TMP_Text>().text = option2;
        answerButtons[2].GetComponentInChildren<TMP_Text>().text = option3;
        

        // Adăugarea funcționalității la butoane
        for (int i = 0; i < 3; i++)
        {
            int index = i; // Pentru a evita problemele cu closure
            answerButtons[i].onClick.AddListener(() => CheckAnswer(answerButtons[index].GetComponentInChildren<TMP_Text>().text));
        }
    }

    private void CheckAnswer(string answer)
    {
        switch (answer)
        {
            case "Resume":
                gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                mouseLook.enabled = true;
                break;
            case "Main Menu":
                SceneManager.LoadScene("Menu");
                break;
            case "Quit":
            #if UNITY_EDITOR
                            UnityEditor.EditorApplication.isPlaying = false;
            #else
                    // If running in a build, quit the application
                    Application.Quit();
            #endif
                break;
            default: break;
        }
    }
}
