using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movementInput;
    private Rigidbody rb;
    public float speed = 5;
    public bool wingRightMissing, wingLeftMissing;
    private GameObject spaceShip;

    private bool isShooting;
    private float delay;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnBulletPoint;

    private float rotX, rotZ;
    private float lerpX = 0.5f, lerpZ = 0.5f;
    [SerializeField] private float addPercent = 0.05f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spaceShip = GameObject.FindGameObjectWithTag("SpaceShip");
    }

    void FixedUpdate()
    {
        //MOVEMENT
        Vector3 movementPosition = movementInput;

        if (wingRightMissing)
        {
            movementPosition.x += 0.1f;
            movementPosition.y -= 0.2f;
        }

        if (wingLeftMissing)
        {
            movementPosition.x -= 0.1f;
            movementPosition.y -= 0.2f;
        }

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
        NewRotation(movementPosition.x, ref lerpZ);
        NewRotation(movementPosition.y, ref lerpX);

        if (movementPosition.y == 0)
            ResetRotation(ref lerpX);
        if(movementPosition.x == 0)
            ResetRotation(ref lerpZ);

        rotX = Mathf.Lerp(-30, 30, lerpX);
        rotZ = Mathf.Lerp(-20, 20, lerpZ);

        spaceShip.transform.eulerAngles = new Vector3(rotX, 180, rotZ);

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
