using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private GameObject explosion;

    [Header("Sound")]
    [SerializeField] private AudioClip explosionAudioClip;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            GameManager.instance.score += 1;
            GameObject expl =  Instantiate(explosion,transform.position,Quaternion.identity);
            AudioSource.PlayClipAtPoint(explosionAudioClip, transform.position, 1);
            Destroy(expl,1.0f);
            Destroy(gameObject);
        }
    }
}
