using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetHeart : MonoBehaviour
{

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Body") || collision.CompareTag("Wing"))
        {
            Debug.Log("Heal");
            AddHealth.isHealing = true;
            Destroy(this.gameObject);
        }
    }
}
