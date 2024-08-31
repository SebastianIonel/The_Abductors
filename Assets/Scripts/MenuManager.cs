using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public Button[] answerButtons;

    public MouseLook mouseLook;

    [SerializeField] private Transform player;
    [SerializeField] private Transform car;
    public int level;

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
                SaveData();
                SceneManager.LoadScene("Menu");
                break;
            case "Quit":
                SaveData();
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

    private void SaveData()
    {
        switch (level) {
            case 0: {
                PlayerPrefs.SetFloat("FizicaPlayerPosX", player.position.x);
                PlayerPrefs.SetFloat("FizicaPlayerPosY", player.position.y);
                PlayerPrefs.SetFloat("FizicaPlayerPosZ", player.position.z);
                PlayerPrefs.SetFloat("FizicaPlayerRotationX", player.eulerAngles.x);
                PlayerPrefs.SetFloat("FizicaPlayerRotationY", player.eulerAngles.y);
                PlayerPrefs.SetFloat("FizicaPlayerRotationZ", player.eulerAngles.z);

                PlayerPrefs.SetFloat("FizicaCarPosX", car.position.x);
                PlayerPrefs.SetFloat("FizicaCarPosY", car.position.y);
                PlayerPrefs.SetFloat("FizicaCarPosZ", car.position.z);
                PlayerPrefs.SetFloat("FizicaCarRotationX", car.eulerAngles.x);
                PlayerPrefs.SetFloat("FizicaCarRotationY", car.eulerAngles.y);
                PlayerPrefs.SetFloat("FizicaCarRotationZ", car.eulerAngles.z);
                break;
            }
            case 1: {
                PlayerPrefs.SetFloat("ChimiePlayerPosX", player.position.x);
                PlayerPrefs.SetFloat("ChimiePlayerPosY", player.position.y);
                PlayerPrefs.SetFloat("ChimiePlayerPosZ", player.position.z);
                PlayerPrefs.SetFloat("ChimiePlayerRotationX", player.eulerAngles.x);
                PlayerPrefs.SetFloat("ChimiePlayerRotationY", player.eulerAngles.y);
                PlayerPrefs.SetFloat("ChimiePlayerRotationZ", player.eulerAngles.z);

                // PlayerPrefs.SetFloat("ChimieCarPosX", car.position.x);
                // PlayerPrefs.SetFloat("ChimieCarPosY", car.position.y);
                // PlayerPrefs.SetFloat("ChimieCarPosZ", car.position.z);
                break;
            }
            case 2: {
                PlayerPrefs.SetFloat("BioPlayerPosX", player.position.x);
                PlayerPrefs.SetFloat("BioPlayerPosY", player.position.y);
                PlayerPrefs.SetFloat("BioPlayerPosZ", player.position.z);
                PlayerPrefs.SetFloat("BioPlayerRotationX", player.eulerAngles.x);
                PlayerPrefs.SetFloat("BioPlayerRotationY", player.eulerAngles.y);
                PlayerPrefs.SetFloat("BioPlayerRotationZ", player.eulerAngles.z);

                // PlayerPrefs.SetFloat("BioCarPosX", car.position.x);
                // PlayerPrefs.SetFloat("BioCarPosY", car.position.y);
                // PlayerPrefs.SetFloat("BioCarPosZ", car.position.z);
                break;
            }
        }
    }
}
