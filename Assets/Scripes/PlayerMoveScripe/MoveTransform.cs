using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransform : MonoBehaviour,IMoveInput//使用Transfrom移动脚本
{
    [SerializeField] private float moveSpeed;//移动速度
    private Vector3 velocityVector; //方向向量
    private Transform transform;

    private void Awake()
    {
        transform = GetComponent<Transform>();
    }

    public void SetVelocity(Vector3 velocityVector)
    {
        this.velocityVector = velocityVector;//调整方向向量
    }

    private void FixedUpdate()
    {
        transform.position += velocityVector * moveSpeed * Time.deltaTime;//移动
    }
}
