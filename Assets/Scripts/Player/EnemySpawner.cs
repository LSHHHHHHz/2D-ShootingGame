using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject[] monsters;
    public int interval = 1;
    Enemy spawnEnemy;
    private void Start()
    {
        StartCoroutine(SpawnMonster());
    }
    IEnumerator SpawnMonster()
    {
        while (true)
        {
            spawnEnemy = PoolManager.instance.setPool((monsters[0])).GetComponent<Enemy>();
            spawnEnemy.transform.position = spawnPoint[UnityEngine.Random.Range(0, spawnPoint.Length)].transform.position;
            yield return new WaitForSeconds(interval);
        }
    }
}
