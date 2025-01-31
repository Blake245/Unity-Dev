using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [SerializeField] GameObject tank;
    [SerializeField] GameObject winUI;
    [SerializeField] GameObject loseUI;
    [SerializeField] Camera loseCamera;

    enum eState
    {
        TITLE,
        GAME,
        WIN,
        LOSE
    }

    eState state = eState.TITLE;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        switch (state)
        {
            case eState.TITLE:
                //titleUI.GetComponent<Image>().enabled = true;
                //titleUI.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
                //titleUI.GetComponentInChildren<Image>().enabled = true;
                ////titleUI.SetActive(true);
                //if (Input.GetKeyDown(KeyCode.Space))
                //{
                //    titleUI.GetComponent<Image>().enabled = false;
                //    titleUI.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
                //    //titleUI.SetActive(false);
                //    state = eState.GAME;
                //}   

                break;
            case eState.GAME:
                Cursor.lockState = CursorLockMode.Locked;
                loseCamera.enabled = false;
                break;
            case eState.WIN:
                loseCamera.enabled = true;
                winUI.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
                tank.GetComponent<AudioListener>().enabled = false;
                loseCamera.GetComponent<AudioListener>().enabled = true;
                break;
            case eState.LOSE:
                //loseUI.GetComponent<Image>().enabled = true;
                loseUI.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
                loseCamera.enabled = true;
                
                //Debug.Log("Lose");
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    loseUI.GetComponent<Image>().enabled = false;
                    loseUI.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
                    state = eState.TITLE;
                }

                break;
            default:
                break;
        }
    }

    public void OnStartGame()
    {
        state = eState.GAME;
        SceneManager.LoadScene("Tank");
    }
    
    public void SetGameOver()
    {
        state = eState.LOSE;
    }

    public void SetGameWin()
    {
        state = eState.WIN;
    }
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
