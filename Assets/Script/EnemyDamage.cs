using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public GameObject objectToDestroy;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            GameManager.instance.score += 1;
            Debug.Log(GameManager.instance.score);
            Destroy(objectToDestroy);
           
        }
    }
}
