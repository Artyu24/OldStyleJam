using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHeart : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Body") || collision.CompareTag("Wing"))
        {
            Debug.Log("Avant clo"+HealthBar.health);
            HealthBar.health += 50;
            if (HealthBar.health > 300)
                HealthBar.health = 300;
            Destroy(this);
            Debug.Log("Apres clo" + HealthBar.health);

        }
    }
}
