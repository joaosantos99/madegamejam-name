using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 8f;
    private float jumpingPower = 5f;
    private float sideJetPower = 7.5f;

    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
           rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetKeyUp(KeyCode.W) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            //Debug.Log("A");
            rb.velocity = new Vector2(-5, jumpingPower);
        }

        if (Input.GetKeyUp(KeyCode.A) && rb.velocity.x > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x * -0.9f, rb.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log("A");
            rb.velocity = new Vector2(5, jumpingPower);
        }

        if (Input.GetKeyUp(KeyCode.D) && rb.velocity.x > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.9f, rb.velocity.y * 0.5f);
        }
    }
}
