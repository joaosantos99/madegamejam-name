using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;

    void Update()
    {
        if (player.transform.position.y > 5.15)
        {
            Debug.Log(transform.position.y);
            transform.position = new Vector3(0, player.transform.position.y, -5);
        }
    }
}
