using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryLose : MonoBehaviour
{
    public static bool isWin = false;
    public static bool isLose = false;
    public GameObject WinManu;
    public GameObject LoseManu;

    

    private void Update()
    {
        if (transform.childCount == 0)
        {
            isWin = true;
        }
        if (isWin)
        {
            YouWin();
        }
        if(isLose)
        {
            YouLose();
        }
    }

    public void YouWin()
    {
        isWin = false;
        Time.timeScale = 0f;
        WinManu.SetActive(true);
    }
    public void YouLose()
    {
        isLose = false;
        Time.timeScale = 0f;
        LoseManu.SetActive(true);
    }

    public void LoadMainManu()
    {
        WinManu.SetActive(false);
        LoseManu.SetActive(false);
        Time.timeScale = 1f;
        if(Time.timeScale==1f)
        StartCoroutine(LoadScene("MainManuScene"));
    }

    public void QuitGame()
    {
        Debug.Log("退出游戏");
        Application.Quit();
    }
    public void LoadNextLevel()
    {
        WinManu.SetActive(false);
        Time.timeScale = 1f;
        StartCoroutine(LoadScene(1));
    }
    public void LoadCurrentLevel()
    {
        Time.timeScale = 1f;
        LoseManu.SetActive(false);
        StartCoroutine(LoadScene(0));
    }


    IEnumerator LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        yield return null;
    }
    IEnumerator LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneIndex);
        yield return null;
    }
}
