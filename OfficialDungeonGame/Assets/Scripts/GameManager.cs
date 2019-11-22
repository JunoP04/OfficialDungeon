using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isEnd;
    public bool isTwo;
    private int nextScene;
    public Button startButton;
    public Button exitButton;
    public string mainScene;
    public GameObject pauseMenu;
    public GameObject inGameHUD;
    public GameObject mainCam;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        isEnd = false;
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnd)
        {
            StartCoroutine(Pause5Seconds());
        }

        if (Input.GetKeyDown(KeyCode.P) && inGameHUD.activeSelf)
        {
            Pause();
        }
        else if(Input.GetKeyDown(KeyCode.P) && pauseMenu.activeSelf)
        {
            UnPause();
        }
  
    }
    IEnumerator Pause5Seconds()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(nextScene);

    }

    public void StartGame()
    {
        SceneManager.LoadScene(mainScene);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        inGameHUD.SetActive(false);
        mainCam.GetComponent<CamMouseLook>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        inGameHUD.SetActive(true);
        mainCam.GetComponent<CamMouseLook>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }




}
