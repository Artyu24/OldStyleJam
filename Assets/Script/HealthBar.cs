using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static int health;
    public Slider sliderUI;

    // Update is called once per frame
    public void Update()
    {
        health = ObjectHealth.life;
        sliderUI.value = health;
        
    }
}
