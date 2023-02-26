using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;

    void Update()
    {
        if (player.transform.position.y > 5.15 )
        {
            transform.position = new Vector3(0, player.transform.position.y, -10);
        }

        if(Input.GetKeyUp(KeyCode.Return) && PlayerMovement.endGame)
        {
            transform.position = new Vector3(0f, 5.16f, -10f);
        }
    }
}
