using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPart : MonoBehaviour
{
    public GameObject curT;
    public GameObject LightTurret;
    public GameObject MediumTurret;
    public GameObject HeavyTurret;

    private void Start()
    {
        if (LightTurret.activeSelf) //检测目前的Turret是什么
        {
            curT = LightTurret;
        }
        else if (MediumTurret.activeSelf)
        {
            curT = MediumTurret;
        }
        else
        {
            curT = HeavyTurret;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchTurret(curT, LightTurret);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchTurret(curT, MediumTurret);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchTurret(curT, HeavyTurret);
        }
    }
    
    
    public void SwitchTurret(GameObject curTurret,GameObject SwitchPart)
    {
        curTurret.SetActive(false);
        SwitchPart.SetActive(true);

        if (LightTurret.activeSelf)
        {
            curT = LightTurret;
        }
        else if(MediumTurret.activeSelf)
        {
            curT = MediumTurret;
        }
        else
        {
            curT = HeavyTurret;
        }             
    }
}
