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
    [SerializeField] private float timeBTWSpawn;

    private bool isSpawn;

    public float speed;


    void Update()
    {

        int num = Random.Range(0, 3);

        randomEnemy = enemy[num];

        if(!isSpawn && GameManager.instance.score < 5)
        {
            speed = 20;
            timeBTWSpawn = 2;
            StartCoroutine(TimerSpawn());
        }
        else if(!isSpawn && GameManager.instance.score < 15)
        {
            speed = 40;
            timeBTWSpawn = 1;
            StartCoroutine(TimerSpawn());
        }
        else if(!isSpawn && GameManager.instance.score < 30)
        {
            speed = 50;
            timeBTWSpawn = 2;
            for (int i = 0; i < 3; i++)
                StartCoroutine(TimerSpawn());
        }
        else if (!isSpawn && GameManager.instance.score < 40)
        {
            speed = 70;
            timeBTWSpawn = 2;
            for (int i = 0; i < 3; i++)
                StartCoroutine(TimerSpawn());
        }
        else if (!isSpawn && GameManager.instance.score < 50)
        {
            speed = 70;
            timeBTWSpawn = 1;
            for(int i = 0; i < 3; i++)
                StartCoroutine(TimerSpawn());
        }
        else if (!isSpawn && GameManager.instance.score < 100)
        {
            speed = 100;
            timeBTWSpawn = 1;
            for(int i = 0; i < 5; i++)
                StartCoroutine(TimerSpawn());
    
        }
        else if (!isSpawn && GameManager.instance.score >= 100)
        {
            speed = 100;
            timeBTWSpawn = 1;
            for (int i = 0; i < 7; i++)
                StartCoroutine(TimerSpawn());

        }



    }


    IEnumerator TimerSpawn()
    {
        isSpawn = true;
        yield return new WaitForSeconds(timeBTWSpawn);

        GameObject stock = Instantiate(randomEnemy, new Vector3(Random.Range(-7, 8), Random.Range(-3, 4), enemyZAxis), Quaternion.Euler(new Vector3(60, 180, 0)));
        Destroy(stock, 5);

        isSpawn = false;
    }

}
