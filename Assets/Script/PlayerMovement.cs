using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movementInput;
    private Rigidbody rb;
    public float speed = 5;
    private bool isShooting;
    private float delay;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnBulletPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 movementPosition = movementInput;
        rb.MovePosition(rb.position + movementPosition * Time.fixedDeltaTime * speed);

        Debug.Log(movementInput);

        delay += Time.fixedDeltaTime;

        if (isShooting && delay >= 0.5f)
        {
            delay = 0;
            Instantiate(bullet, spawnBulletPoint.position, Quaternion.identity);
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
            isShooting = true;
        else if (context.canceled)
            isShooting = false;
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
}
