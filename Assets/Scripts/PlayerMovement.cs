using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float straightJumpingPower;
    [SerializeField] private float sideJumpPower;
    [SerializeField] private float sidePower;

    private bool endGame = false;

    //Fuel Props
    public float maxFuel = 100;
    public float currentFuel = 100;
    private float lossFuel = 5;

    void Update()
    {
        //StraightJump
        if (Input.GetKeyDown(KeyCode.W) && currentFuel > 0 && !endGame)
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.5f, straightJumpingPower);
            currentFuel -= lossFuel;
        }

        if (Input.GetKeyUp(KeyCode.W) && rb.velocity.y > 0f && !endGame)
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.5f, rb.velocity.y * 0.5f);
        }

        // LeftJump
        if (Input.GetKeyDown(KeyCode.A) && currentFuel > 0 && !endGame)
        {
            rb.velocity = new Vector2(-sidePower, sideJumpPower);
            currentFuel -= lossFuel;
        }

        if (Input.GetKeyUp(KeyCode.A) && rb.velocity.x > 0f && !endGame)
        {
            rb.velocity = new Vector2(rb.velocity.x * -0.9f, rb.velocity.y * 0.5f);
        }

        //RightJump
        if (Input.GetKeyDown(KeyCode.D) && currentFuel > 0 && !endGame)
        {
            rb.velocity = new Vector2(sidePower, sideJumpPower);
            currentFuel -= lossFuel;
        }

        if (Input.GetKeyUp(KeyCode.D) && rb.velocity.x < 0f && !endGame)
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.9f, rb.velocity.y * 0.5f);
        }

        //FuelRecovery
        if(IsGrounded() && currentFuel != maxFuel && !endGame)
        {
            currentFuel += 1;
        }

        //RestartGame
        if (Input.GetKeyDown(KeyCode.Space) && endGame)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("JerryCan"))
        {
            Destroy(other.gameObject);
            currentFuel = maxFuel;
        }

        if(other.gameObject.CompareTag("Meteor"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            endGame = true;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
