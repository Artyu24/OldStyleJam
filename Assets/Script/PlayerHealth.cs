using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int life;
    [SerializeField] private int maxLife;

    private void Awake()
    {
        life = maxLife;
    }



    public void TakeDamage(int damage)
    {
        life -= damage;
    }
}
