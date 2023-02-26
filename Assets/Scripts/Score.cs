using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] TextMeshProUGUI scoreObject;
    public static int heightsScore = 0;
    private int currentScore = 0;

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
