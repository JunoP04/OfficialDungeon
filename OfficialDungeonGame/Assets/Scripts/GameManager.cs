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
    public 


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
}
