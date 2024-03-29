using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    public float speed;
    private Vector2 move;

    public float dashSpeed;

    public float dashDistance = 0.5f;
    public float dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolTimer;

    Vector3 lookPos;


    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        movePlayer();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            lookPos = hit.point;
        }

        Vector3 lookDir = lookPos - transform.position;
        lookDir.y = 0f;
        transform.LookAt(transform.position + lookDir, Vector3.up);

        Dash();
    }

    public void movePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y).normalized;

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

public void Dash()
{
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (dashCoolTimer <= 0 && dashCoolTimer <= 0)
            {
                speed = dashSpeed;
                dashCounter = dashDistance;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                speed = 5f;
                dashCoolTimer = dashCooldown;
            }
        }

        if (dashCoolTimer > 0)
        {
            dashCoolTimer -= Time.deltaTime;
        }
    }
}

