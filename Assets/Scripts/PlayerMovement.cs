using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TMP_InputField inputName;
    [SerializeField] private TextMeshProUGUI leaderboardObject;
    [SerializeField] private float straightJumpingPower;
    [SerializeField] private float sideJumpPower;
    [SerializeField] private float sidePower;

    //Animations
    private Animator anim;

    //SoundEffects
    private AudioSource audioData;

    public static bool endGame = false;
    public static bool restartGame = false;
    private Vector2 originalPos;
    private Leaderboard leaderboard;

    //Fuel Props
    public float maxFuel = 100;
    public float currentFuel = 100;
    private float lossFuel = 5;

    void Start()
    {
        anim = player.GetComponent<Animator>();
        audioData = GetComponent<AudioSource>();
        leaderboard = new Leaderboard();
        inputName.enabled = false;
        originalPos = new Vector2(rb.position.x, rb.position.y);
        anim.Play("idle");
    }

    void Update()
    {
        //StraightJump
        if (Input.GetKeyDown(KeyCode.W) && currentFuel > 0 && !endGame)
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.5f, straightJumpingPower);
            anim.Play("Middle_Animation");
            audioData.Play(0);
            currentFuel -= lossFuel;
        }

        if (Input.GetKeyUp(KeyCode.W) && rb.velocity.y > 0f && !endGame)
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.5f, rb.velocity.y * 0.5f);
            anim.Play("idle");
        }

        // LeftJump
        if (Input.GetKeyDown(KeyCode.A) && currentFuel > 0 && !endGame)
        {
            rb.velocity = new Vector2(-sidePower, sideJumpPower);
            anim.Play("Right_Animation");
            audioData.Play(0);

            currentFuel -= lossFuel;
        }

        if (Input.GetKeyUp(KeyCode.A) && rb.velocity.x > 0f && !endGame)
        {
            rb.velocity = new Vector2(rb.velocity.x * -0.9f, rb.velocity.y * 0.5f);
            anim.Play("idle");
        }

        //RightJump
        if (Input.GetKeyDown(KeyCode.D) && currentFuel > 0 && !endGame)
        {
            rb.velocity = new Vector2(sidePower, sideJumpPower);
            anim.Play("Left_Animation");
            audioData.Play(0);
            currentFuel -= lossFuel;
        }

        if (Input.GetKeyUp(KeyCode.D) && rb.velocity.x < 0f && !endGame)
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.9f, rb.velocity.y * 0.5f);
            anim.Play("idle");
        }

        //FuelRecovery
        if (IsGrounded() && currentFuel != maxFuel && !endGame)
        {
            currentFuel += 1;
        }

        //Magic Fuel Input
        if (Input.GetKeyDown(KeyCode.Alpha2) && currentFuel != maxFuel && !endGame)
        {
            currentFuel = 100;
        }


        //LeaderBoard
        /*if (Input.GetKeyDown(KeyCode.Return) && endGame && !restartGame)
        {
            leaderboard.addScore(inputName.text, Score.heightsScore);

            inputName.GetComponent<CanvasGroup>().alpha = 0f;
            leaderboardObject.GetComponent<CanvasGroup>().alpha = 1f;
            leaderboardObject.text = "LeaderBoard: \n";
            for(int i = 0; i < leaderboard.scoresList.Count; i++)
            {
                leaderboardObject.text += $"{leaderboard.scoresList[i].name} - {leaderboard.scoresList[i].score}\n";
            }
        }

        if (Input.GetKeyUp(KeyCode.Return) && endGame && !restartGame)
        {
            restartGame = true;
        }

        //RestartGame
        if (Input.GetKeyDown(KeyCode.Return) && restartGame)
        {
            restartGame = false;
            inputName.enabled = false;
            rb.position = originalPos;
            currentFuel = maxFuel;
            endGame = false;
            leaderboardObject.GetComponent<CanvasGroup>().alpha = 0f;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }*/


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
            //rb.constraints = RigidbodyConstraints2D.FreezeAll;
            //endGame = true;
            //inputName.enabled = true;
            //inputName.GetComponent<CanvasGroup>().alpha = 1f;
            SceneManager.LoadScene("Star Menu");
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
