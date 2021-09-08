using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform Enemy;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }


    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(Random.Range(5, 10));
        Instantiate(Enemy, this.transform.position, this.transform.rotation);
        StartCoroutine(SpawnEnemy());
    }
}
