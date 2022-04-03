using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetHeart : MonoBehaviour
{

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Body") || collision.CompareTag("Wing"))
        {
            Debug.Log("Touch� coeur !!");
            HealthBar.healthUp = true;
            Destroy(this.gameObject);
        }
    }
}
