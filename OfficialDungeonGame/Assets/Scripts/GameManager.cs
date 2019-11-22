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

    //new bool check if mouse visible
    private bool mouseVisible = false;

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

        //Escape key pauses and unpauses the game and brings up either the pause menu or HUD
        if (Input.GetKeyDown(KeyCode.Escape) && inGameHUD.activeSelf)
        {
            Pause();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeSelf)
        {
            UnPause();
        }
    }
    IEnumerator Pause5Seconds()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(nextScene);

    }

    //Main Menu Scripts to load the game scene
    //ONLY RUNS IN BUILDS OF THE GAME
    public void StartGame()
    {
        SceneManager.LoadScene(mainScene);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    //Pauses the game and unlocks the cursor and stops time
    public void Pause()
    {
        Time.timeScale = 0;
        mainCam.GetComponent<CamMouseLook>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        mouseVisible = true;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        inGameHUD.SetActive(false);
    }

    //Unpauses the game, resumes time, locks cursor to the centre of the camera
    public void UnPause()
    {
        Time.timeScale = 1;
        mainCam.GetComponent<CamMouseLook>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        mouseVisible = false;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        inGameHUD.SetActive(true);
    }
}
