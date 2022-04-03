using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10;
    [SerializeField] private float radiusHelpTarger = 1f;

    [Header("Sound")]
    [SerializeField] private AudioClip[] piouAudioClip;

    private void Awake()
    {
        int r = Random.Range(0, piouAudioClip.Length );


        AudioClip piou = piouAudioClip[r];

        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.forward * speed;
        Destroy(gameObject,5);

        AudioSource.PlayClipAtPoint(piou, transform.position, 1);
    }

    private void Update()
    {
        RaycastHit[] hit = Physics.CapsuleCastAll(transform.position + Vector3.forward * 2, transform.position + Vector3.forward * 20, radiusHelpTarger, transform.forward, 20);
        if (hit.Length != 0)
        {
            foreach (RaycastHit raycast in hit)
            {
                if (raycast.transform.gameObject.tag == "Enemy")
                    rb.velocity = (raycast.transform.position - transform.position).normalized * speed;
                else
                    rb.velocity = Vector3.forward * speed;
            }
        }
        else
            rb.velocity = Vector3.forward * speed;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Enemy"))
            this.gameObject.SetActive(false);
    }
}
