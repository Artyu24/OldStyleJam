using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    private GameObject randomEnemy;

    private float enemyXAxis;
    private float enemyYAxis;
    [SerializeField] private float enemyZAxis = 20f;
    [SerializeField] private float timeBTWSpawn = 2;

    private bool isSpawn;

    private Rigidbody rb;
    public float speed = 10;


    void Update()
    {
        enemyXAxis = Random.Range(-9, 10);
        enemyYAxis = Random.Range(-5, 6);

        int num = Random.Range(0, 3);

        randomEnemy = enemy[num];

        if(!isSpawn)
            StartCoroutine(TimerSpawn());

        
    }

    IEnumerator TimerSpawn()
    {
        isSpawn = true;
        yield return new WaitForSeconds(timeBTWSpawn);

        GameObject stock = Instantiate(randomEnemy, new Vector3(enemyXAxis, enemyYAxis, enemyZAxis), Quaternion.identity);

        Destroy(stock, 5);
        isSpawn = false;
    }
}
