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
        Vector3 playerMovement = rb.position + movementPosition * Time.fixedDeltaTime * speed;
        
        if (playerMovement.x >= 9)
            playerMovement.x = 9;
        else if(playerMovement.x <= -9)
            playerMovement.x = -9;

        if (playerMovement.y >= 5)
            playerMovement.y = 5;
        else if(playerMovement.y <= -5)
            playerMovement.y = -5;

        rb.MovePosition(playerMovement);

        Debug.Log(movementInput);

        delay += Time.fixedDeltaTime;

        if (isShooting && delay >= 0.25f)
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
