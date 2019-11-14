using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isEnd;
    private int nextScene;
    public Button startButton;
    public Button exitButton;
    public string mainScene;

    // Start is called before the first frame update
    void Start()
    {
        //don't destroy
        DontDestroyOnLoad(this.gameObject);
        //Scene loads un-ended
        isEnd = false;
        //prepare the next scene
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        //if the level has ended run delay co-routine
        if (isEnd)
        {
            StartCoroutine(Pause5Seconds());
        }
    }
    //pause 5 seconds then load next scene
    IEnumerator Pause5Seconds()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(nextScene);

    }

    public void StartGame()
    {
        //on start, load main scene
        SceneManager.LoadScene(mainScene);
    }

    //end game function
    public void EndGame()
    {
        Application.Quit();
    }
}
