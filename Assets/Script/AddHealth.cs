using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class AddHealth : MonoBehaviour
{
    public Slider sliderUI;
    public static bool isHealing;

    private void Update()
    {
        if(isHealing)
            AddLife();
    }
    public void AddLife()
    {
        Debug.Log("Healt :" + HealthBar.health);
        HealthBar.health += 50;

        sliderUI.value += 50;
        Debug.Log("Healt :" + HealthBar.health);

    }
}
