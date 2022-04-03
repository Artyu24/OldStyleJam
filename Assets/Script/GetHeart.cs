using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHeart : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(this);
            HealthBar.health += 50;
            if (HealthBar.health > 300)
                HealthBar.health = 300;
        }
    }
}
