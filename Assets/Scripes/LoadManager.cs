using System.Collections;
using System.Collections.Generic;
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

    public void LoadNextLevel()
    {
        
        StartCoroutine(LoadLevel());
        
    }

    IEnumerator  LoadLevel()
    {

        Manu.SetActive(false);
        LoadScreen.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            Slider.value = operation.progress;
         
            text.text = operation.progress * 100 + "%";

            if(operation.progress >= 0.9f)
            {
                Slider.value = 1;
                
                text.text = "Press Any Key to continue";

                if (Input.anyKeyDown)
                {
                    operation.allowSceneActivation = true;
                }
            }
            yield return null;

        }
    }

    
}
