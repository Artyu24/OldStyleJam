using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderValueUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Slider sliderUI;
    public Text textSliderValue;
    // Update is called once per frame
    void Update()
    {
        
    }
    public void printValue()
    {
        textSliderValue.text = (string.Format("{0:N2}", sliderUI.value).Remove((string.Format("{0:N2}", sliderUI.value).Length-3))+"%");
    }
}
