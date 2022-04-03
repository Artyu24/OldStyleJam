using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    public int life;
    [SerializeField] private int maxLife;
    private GameObject mainPlayerPart;
    [SerializeField] private GameObject explosion;
    [Header("Sound")]
    [SerializeField] private AudioClip damageAudioClip;

    private void Awake()
    {
        mainPlayerPart = GameObject.FindGameObjectWithTag("Body");
        life = maxLife;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(gameObject.name + " have take damage");

        life -= damage;
        if (life <= 0)
        {
            switch (tag)
            {
                case "Wing":
                    Explosion();
                    
                    GameObject player = GameObject.FindGameObjectWithTag("Player");
                    string objectName = name;
                    if (name[0] == 'L')
                        player.GetComponent<PlayerMovement>().wingLeftMissing = true;
                    else
                        player.GetComponent<PlayerMovement>().wingRightMissing = true;
                    break;

                case "Player":
                    break;

                default:
                    break;
            }
        }
    }

    private void Explosion()
    {
        GetComponent<BreakWing>().DestroyWing();
    }

    private void Death()
    {
        Debug.Log("et ba perdu mon gros");
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
            GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(damageAudioClip, transform.position, 1);
            Destroy(expl, 1.0f);

            TakeDamage(35);

            if (CompareTag("Wing"))
            {
                mainPlayerPart.GetComponent<ObjectHealth>().TakeDamage(5);
            }
        }
    }
}
