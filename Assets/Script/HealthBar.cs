using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static int health;
    private int healthLeft;
    private int healthRight;
    public Slider sliderUI;
    public Slider sliderLeft;
    public Slider sliderRight;
    public GameObject spaceShip;
    public GameObject leftWing;
    public GameObject rightWing;
    public GameObject body;


    private void Start()
    {
        sceneManager.isGameOver = false;
    }
    void Update()
    {


        if (leftWing!=null)
            healthLeft = leftWing.GetComponent<ObjectHealth>().life;
        else
            healthLeft = 0;

        if (rightWing != null)
            healthRight = rightWing.GetComponent<ObjectHealth>().life;
        else
            healthRight = 0;

        if ((body.GetComponent<ObjectHealth>().life)>=0)
            health = ((body.GetComponent<ObjectHealth>().life) + healthLeft + healthRight);
        else
            health = (healthLeft + healthRight);




        if (health <= 0)
        { 
            Debug.Log("GameOver");
            StartCoroutine(GameOver());
        }

        sliderUI.value = health;
        sliderLeft.value = healthLeft;
        sliderRight.value = healthRight;
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2);
        //health = 300;
        sceneManager.isGameOver = true;
    }
}
