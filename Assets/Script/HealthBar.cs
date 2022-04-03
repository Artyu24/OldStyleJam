using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static int health;
    private int healthLeft;
    private int healthRight;

    public static bool healthUp;

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


        if (healthUp)
        {

            if (leftWing != null)
                if (leftWing.GetComponent<ObjectHealth>().life <= 90)
                {
                    leftWing.GetComponent<ObjectHealth>().life += 10;
                    healthLeft = leftWing.GetComponent<ObjectHealth>().life;
                }
                else
                    healthLeft = leftWing.GetComponent<ObjectHealth>().life;
            else
                healthLeft = 0;


            if (rightWing != null)
                if (rightWing.GetComponent<ObjectHealth>().life <= 90)
                {
                    rightWing.GetComponent<ObjectHealth>().life += 10;
                    healthLeft = rightWing.GetComponent<ObjectHealth>().life;
                }
                else
                    healthLeft = rightWing.GetComponent<ObjectHealth>().life;
            else
                healthLeft = 0;


            if ((body.GetComponent<ObjectHealth>().life) >= 0)
                if (body.GetComponent<ObjectHealth>().life <= 90)
                {
                    body.GetComponent<ObjectHealth>().life += 10;
                    health = ((body.GetComponent<ObjectHealth>().life) + healthLeft + healthRight);
                }
                else
                    health = ((body.GetComponent<ObjectHealth>().life) + healthLeft + healthRight);
            else
                health = (healthLeft + healthRight);

            healthUp = false;
        }
        else if (healthUp == false)
        {

            if (leftWing != null)
                healthLeft = leftWing.GetComponent<ObjectHealth>().life;
            else
                healthLeft = 0;


            if (rightWing != null)
                healthRight = rightWing.GetComponent<ObjectHealth>().life;
            else
                healthRight = 0;


            if ((body.GetComponent<ObjectHealth>().life) >= 0)
            { 
                health = ((body.GetComponent<ObjectHealth>().life) + healthLeft + healthRight );
            }
            else
                health = (healthLeft + healthRight);
        }



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
