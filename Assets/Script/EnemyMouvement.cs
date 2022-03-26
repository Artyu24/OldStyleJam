using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMouvement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.forward * -1 * speed;
        Destroy(gameObject, 5);
    }
}
