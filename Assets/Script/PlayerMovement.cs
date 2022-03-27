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

    private float rotX, rotZ;
    private float lerpX = 0.5f, lerpZ = 0.5f;
    [SerializeField] private float addPercent = 0.05f;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnBulletPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //MOVEMENT
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

        //ROTATION
        NewRotation(movementInput.x, ref lerpZ);
        NewRotation(movementInput.y, ref lerpX);

        if (movementInput == Vector2.zero)
        {
            ResetRotation(ref lerpX);
            ResetRotation(ref lerpZ);
        }

        rotX = Mathf.Lerp(-40, 40, lerpX);
        rotZ = Mathf.Lerp(-30, 30, lerpZ);

        transform.eulerAngles = new Vector3(rotX, 0, rotZ);

        //SHOOT
        delay += Time.fixedDeltaTime;

        if (isShooting && delay >= 0.25f)
        {
            delay = 0;
            Instantiate(bullet, spawnBulletPoint.position, Quaternion.identity);
        }
    }

    private void NewRotation(float movementInputAxis, ref float percentRotation)
    {
        if (movementInputAxis > 0 && percentRotation > 0)
            percentRotation -= addPercent * Mathf.Abs(movementInputAxis);
        else if (movementInputAxis < 0 && percentRotation < 1)
            percentRotation += addPercent * Mathf.Abs(movementInputAxis);
    }

    private void ResetRotation(ref float percentRotation)
    {
        if (percentRotation > 0.45f && percentRotation < 0.55f)
            percentRotation = 0.5f;
        else if (percentRotation > 0.5f)
            percentRotation -= addPercent / 2;
        else if (percentRotation < 0.5f)
            percentRotation += addPercent / 2;
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
