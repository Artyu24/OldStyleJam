using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHeart : MonoBehaviour
{

    public Slider sliderUI;
    

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
            sliderUI.value = HealthBar.health;


        }
    }
}
