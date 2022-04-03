using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSpawn : MonoBehaviour
{
    [SerializeField] private GameObject hearth;

    [SerializeField] private float ZAxis = 20f;
    [SerializeField] private float timeBTWSpawn;
    public Slider sliderUI;

    private bool isSpawn;

    void Update()
    {

        if (!isSpawn && HealthBar.health < 100)
        {
            timeBTWSpawn = 5;
            StartCoroutine(TimerSpawn());
        }
        else if (!isSpawn && HealthBar.health < 200)
        {
            timeBTWSpawn = 10;
            StartCoroutine(TimerSpawn());
        }
        else if (!isSpawn && HealthBar.health < 300)
        {
            timeBTWSpawn = 15;
            StartCoroutine(TimerSpawn());
        }

    }



    IEnumerator TimerSpawn()
    {
        isSpawn = true;
        yield return new WaitForSeconds(timeBTWSpawn);

        GameObject stock = Instantiate(hearth , new Vector3(Random.Range(-7, 8), Random.Range(-3, 4), ZAxis), Quaternion.Euler(new Vector3(0, 180, 0)));
        Destroy(stock, 5);

        isSpawn = false;
    }

}
