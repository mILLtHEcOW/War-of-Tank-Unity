using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCamera : MonoBehaviour
{
    public Transform Target;      
    void FixedUpdate()
    {
        if (Target != null)//
        {
            transform.position = Target.position;
        }
    }
}
