using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShotInput : MonoBehaviour
{
    public bool isReady;

    private void Start()
    {
        isReady = true;
    }

    private void Update()
    {
        if (ManuPause.GameisPause)//游戏暂停时候停止检测
            return;
        if (Input.GetKeyDown(KeyCode.Mouse0) && isReady == true)
        {
            GetComponent<ITankShotInput>().Shoot();
            //isReady = false;
            //StartCoroutine(CoolDown());
        }
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(0.5f);
        isReady = true;
    }
}