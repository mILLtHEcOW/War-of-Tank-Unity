using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Barrel : MonoBehaviour
{
    public GameObject barrelComplete;
    public GameObject barrelBreaked;

    private void Awake()
    {
        barrelComplete.SetActive(true);
        barrelBreaked.SetActive(false);
    }

    void OnCollisionEnter(Collision other)
    {
        this.Destroy();
    }

    private void Destroy() //生成摧毁的桶、去掉原来的桶、取消碰撞器、播放摧毁音效
    {
        barrelBreaked.SetActive(true);
        Destroy(barrelComplete);
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<AudioSource>().Play();
    }
}
