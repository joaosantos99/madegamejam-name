using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerMovement playerMovement;
    private Image fuelBar;

    void Start()
    {
        fuelBar = GetComponent<Image>();
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        fuelBar.fillAmount = playerMovement.currentFuel / playerMovement.maxFuel;
    }
}
