using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float straightJumpingPower;
    [SerializeField] private float sideJumpPower;
    [SerializeField] private float sidePower;

    void Update()
    {
        //StraightJump
        if (Input.GetKeyDown(KeyCode.W))
        {
           rb.velocity = new Vector2(rb.velocity.x, straightJumpingPower);
        }

        if (Input.GetKeyUp(KeyCode.W) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        // LeftJump
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = new Vector2(-sidePower, sideJumpPower);
        }

        if (Input.GetKeyUp(KeyCode.A) && rb.velocity.x > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x * -0.9f, rb.velocity.y * 0.5f);
        }

        //RightJump
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity = new Vector2(sidePower, sideJumpPower);
        }

        if (Input.GetKeyUp(KeyCode.D) && rb.velocity.x < 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.9f, rb.velocity.y * 0.5f);
        }
    }
}
