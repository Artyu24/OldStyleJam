 using System.Collections;
using System.Collections.Generic;
 using UnityEngine;

public class BreakWing : MonoBehaviour
{
    [SerializeField] private GameObject fracturedGameObject;
    [SerializeField] private float breakForce;

    public void DestroyWing()
    {
        GameObject frac = Instantiate(fracturedGameObject, transform.position, Quaternion.Euler(0,-180,0));

        foreach (Rigidbody rb in frac.GetComponentsInChildren<Rigidbody>())
        {
            Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
            rb.AddForce(force);
        }

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;


    }
}