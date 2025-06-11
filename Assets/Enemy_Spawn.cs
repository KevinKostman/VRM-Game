using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    public GameObject[] enemies;
    private int amount;
    bool spawnPointSet;
    public LayerMask whatIsGround;
    public Vector3 spawnPoint;


    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        amount = enemies.Length;
        if (amount <= 2)
        {
            InvokeRepeating("SpawnEnemy", 1, 10f);
        }
    }
    void SpawnEnemy()
    {
        spawnPoint.x = Random.Range(0,10);
        spawnPoint.y = 0;
        spawnPoint.z = Random.Range(0,10);
        Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Length)], spawnPoint, Quaternion.identity);
        CancelInvoke();
            
        
    }
}
