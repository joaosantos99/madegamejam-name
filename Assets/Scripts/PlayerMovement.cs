using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float straightJumpingPower;
    [SerializeField] private float sideJumpPower;
    [SerializeField] private float sidePower;

    //Fuel Props
    public float maxFuel = 100;
    public float currentFuel = 100;
    private float lossFuel = 5;

    void Update()
    {
        //StraightJump
        if (Input.GetKeyDown(KeyCode.W) && currentFuel > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, straightJumpingPower);
            currentFuel -= lossFuel;
            Debug.Log(currentFuel);
        }

        if (Input.GetKeyUp(KeyCode.W) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        // LeftJump
        if (Input.GetKeyDown(KeyCode.A) && currentFuel > 0)
        {
            rb.velocity = new Vector2(-sidePower, sideJumpPower);
            currentFuel -= lossFuel;
            Debug.Log(currentFuel);
        }

        if (Input.GetKeyUp(KeyCode.A) && rb.velocity.x > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x * -0.9f, rb.velocity.y * 0.5f);
        }

        //RightJump
        if (Input.GetKeyDown(KeyCode.D) && currentFuel > 0)
        {
            rb.velocity = new Vector2(sidePower, sideJumpPower);
            currentFuel -= lossFuel;
            Debug.Log(currentFuel);
        }

        if (Input.GetKeyUp(KeyCode.D) && rb.velocity.x < 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.9f, rb.velocity.y * 0.5f);
        }

        //FuelRecovery
        if(IsGrounded() && currentFuel != maxFuel)
        {
            currentFuel += 1;
            Debug.Log(currentFuel);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
