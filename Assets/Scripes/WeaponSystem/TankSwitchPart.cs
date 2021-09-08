using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TankTurret { lightTurret,mediumTurret,heavyTurret}


public class TankSwitchPart : MonoBehaviour
{
    public GameObject curT;
    public GameObject LightTurret;
    public GameObject MediumTurret;
    public GameObject HeavyTurret;
    private AudioSource equipAudio; 
    private void Start()
    {
        equipAudio = GetComponent<AudioSource>();
        if (LightTurret.activeSelf) //检测目前的Turret是哪个
        {
            curT = LightTurret;
        }
        else if (MediumTurret.activeSelf)
        {
            curT = MediumTurret;
        }
        else if(HeavyTurret.activeSelf)
        {
            curT = HeavyTurret;
        }
        else
        curT =LightTurret;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchTurret(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchTurret( 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchTurret( 2);
        }
    }


    public void SwitchTurret(int i)
    {
        curT.SetActive(false);
        switch (i)
        {
            case (int)TankTurret.lightTurret:
                LightTurret.SetActive(true);
                curT = LightTurret;
                break;
            case (int)TankTurret.mediumTurret:
                MediumTurret.SetActive(true);
                curT = MediumTurret;
                break;
            case (int)TankTurret.heavyTurret:
                HeavyTurret.SetActive(true);
                curT = HeavyTurret;
                break;
        }
        equipAudio.Play();
    }

}
