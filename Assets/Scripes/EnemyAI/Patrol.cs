using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    private Vector3[] patrolPointArray = { new Vector3(-3,0,1),new Vector3(10, 0, -18), new Vector3(10, 0, 20), new Vector3(-7, 0, 20), new Vector3(-7, 0, -3) };
    public Vector3 patrolPoint;
    private NavMeshAgent nav;

    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        
    }
    private void Update()
    {

    }

    public void PatorlTo()
    {
        GetRandomPoint();
        nav.destination = patrolPoint;
    }

    private void GetRandomPoint()
    {
        patrolPoint = patrolPointArray[Random.Range(0, patrolPointArray.Length)];
    }

}
