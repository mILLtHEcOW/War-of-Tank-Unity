using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVelocity : MonoBehaviour,IMoveInput//使用Rigibody.velocity移动脚本
{
    [SerializeField] private float moveSpeed;
    private Vector3 velocityVector;
    private Rigidbody rigibody;

    private void Awake()
    {
        rigibody = GetComponent<Rigidbody>();
    }

    public void SetVelocity(Vector3 velocityVector)
    {
        this.velocityVector = velocityVector;
    }

    private void FixedUpdate()
    {
        rigibody.velocity = velocityVector * moveSpeed;
    }
}
