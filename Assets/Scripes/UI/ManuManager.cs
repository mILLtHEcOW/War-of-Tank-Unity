using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class ManuManager : MonoBehaviour//StartButton的功能在LoadManger那里；
{
    public AudioMixer MainMixer;
    public void SetVolume(float volume)
    {
        MainMixer.SetFloat("MainVolume", volume);
    }
    
    public void Exit()
    {
        Debug.Log("Exit game");
        Application.Quit();
    }
}
