using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderValueUpdate : MonoBehaviour
{
    public Slider sliderUI;
    public Text textSliderValue;
    void Start()
    {
        textSliderValue.text = ("60%");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void printValue()
    {
        textSliderValue.text = (string.Format("{0:N2}", sliderUI.value).Remove((string.Format("{0:N2}", sliderUI.value).Length-3))+"%");
    }
}
