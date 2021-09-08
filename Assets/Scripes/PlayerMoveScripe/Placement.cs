﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    public LayerMask Ground;//仅地面
    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray,out RaycastHit hitInfo,Mathf.Infinity,Ground))
        {
            transform.position= hitInfo.point;//物体位置为鼠标位置
        }
    }
}
