using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed = 7;
    [SerializeField]
    public float RotateSpeed = 150;

    //public GameObject cannon;
    //public GameObject mouse;
    void FixedUpdate()
    {
        //if (Input.GetKey(KeyCode.S))
        //{
        //    Debug.Log("back");
        //    float horizontal = Input.GetAxis("Horizontal");
        //    float vertical = Input.GetAxis("Vertical");
        //    transform.Translate(new Vector3(0, 0, 1) * MoveSpeed * Time.deltaTime * vertical);
        //    transform.Rotate(new Vector3(0, 1, 0) * -RotateSpeed * Time.deltaTime * horizontal);
        //}
        //else
        //{
        //    Debug.Log("forward");
        //    float horizontal = Input.GetAxis("Horizontal");
        //    float vertical = Input.GetAxis("Vertical");
        //    transform.Translate(new Vector3(0, 0, 1) * MoveSpeed * Time.deltaTime * vertical);
        //    transform.Rotate(new Vector3(0, 1, 0) * RotateSpeed * Time.deltaTime * horizontal);
        //}

        Debug.Log("forward");
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(0, 0, 1) * MoveSpeed * Time.deltaTime * vertical);
        transform.Rotate(new Vector3(0, 1, 0) * RotateSpeed * Time.deltaTime * horizontal);                        
    }
}
