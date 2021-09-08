using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LoadManager : MonoBehaviour
{
    public GameObject LoadScreen;
    public GameObject Manu;
    public Slider Slider;
    public Text text;
    public int SceneNumber;
    
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }
    //测试
    IEnumerator LoadLevel()
    {
        Manu.SetActive(false);
        LoadScreen.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneNumber);

        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            Slider.value = operation.progress;

            text.text = operation.progress * 100 + "%";

            if (operation.progress >= 0.9f)
            {
                Slider.value = 1;

                text.text = "请按任意键以继续";

                if (Input.anyKeyDown)
                {
                    operation.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }
    public void SetLevelOne()
    {
        SceneNumber = 1;
    }
    public void SetLevelTwo()
    {
        SceneNumber = 2;
    }
    public void SetLevelThree()
    {
        SceneNumber = 3;
    }

}