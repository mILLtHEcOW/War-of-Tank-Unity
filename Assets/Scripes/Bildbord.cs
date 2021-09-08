using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bildbord : MonoBehaviour
{
    
    public GameObject cameraPosition;

    private void Awake()
    {
        cameraPosition = GameObject.FindWithTag("MainCamera");
    }

    private void LateUpdate()
    {
        this.transform.LookAt(this.transform.position + cameraPosition.transform.forward);
    }
}
