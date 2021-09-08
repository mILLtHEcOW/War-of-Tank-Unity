using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInput : MonoBehaviour
{

    private void Update()
    {
        float moveZ = 0f;
        float moveX = 0f;
        if (Input.GetKey(KeyCode.UpArrow)) moveZ = +1;
        if (Input.GetKey(KeyCode.DownArrow)) moveZ = -1;
        if (Input.GetKey(KeyCode.LeftArrow)) moveX = -1;
        if (Input.GetKey(KeyCode.RightArrow)) moveX = +1;
        if (Input.GetKey(KeyCode.W)) moveZ = +1;
        if (Input.GetKey(KeyCode.S)) moveZ = -1;
        if (Input.GetKey(KeyCode.A)) moveX = -1;
        if (Input.GetKey(KeyCode.D)) moveX = +1;
        //动画
        GetComponent<Animator>().SetFloat("moveZ", moveZ); //Anim控制shassis旋转方向
        GetComponent<Animator>().SetFloat("moveX", moveX);
        Vector3 moveVector = new Vector3(moveX,0, moveZ).normalized;//归一化向量
        //
        GetComponent<IMoveInput>().SetVelocity(moveVector);
    }
}
