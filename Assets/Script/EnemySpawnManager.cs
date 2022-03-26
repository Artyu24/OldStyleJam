using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    private float enemyXAxis;
    private float enemyYAxis;
    private float enemyZAxis = 20f;

    void Start()
    {

    }


    void Update()
    {
        enemyXAxis = Random.Range(-9, 10);
        enemyYAxis = Random.Range(-5, 6);

        GameObject stock = Instantiate(enemy, new Vector3(enemyXAxis, enemyYAxis, enemyZAxis), Quaternion.identity);

        Destroy(stock, 5);
    }
}
