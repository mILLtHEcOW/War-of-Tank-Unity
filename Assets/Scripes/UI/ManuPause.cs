using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ManuPause : MonoBehaviour
{
    public static bool GameisPause = false;
    public GameObject PauseManuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }

    public void Resume()
    {
        PauseManuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPause = false;
    }

    void Pause()
    {   
        PauseManuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPause = true;
    }

    public void LoadMainManu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainManuScene");
    }

    public void QuitGame()
    {
        Debug.Log("退出游戏");
        Application.Quit();
    }

}
