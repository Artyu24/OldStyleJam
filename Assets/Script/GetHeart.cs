using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;


public class GetHeart : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] private AudioClip bonusAudioClip;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Body") || collision.CompareTag("Wing"))
        {
            Debug.Log("Heal");
            AddHealth.isHealing = true;
            AudioSource.PlayClipAtPoint(bonusAudioClip, transform.position, 1);
            Destroy(this.gameObject);

        }


    }
}
