using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] TextMeshProUGUI scoreObject;
    public static int heightsScore = 0;
    public static int currentScore = 0;

    void Start()
    {
        heightsScore = 0;
        currentScore = 0;
    }

    void Update()
    {
        currentScore = (int)player.transform.position.y - 1;

        if (heightsScore < currentScore )
        {
            heightsScore = currentScore;
            scoreObject.text = "Score: " + heightsScore; 
        }
    }
}
