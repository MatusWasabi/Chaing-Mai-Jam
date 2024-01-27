using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int startHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private TextMeshProUGUI healthText;

    private void Start()
    {
        CombinationBar.OnBeAngried += ReduceHealth;
        currentHealth = startHealth;
        healthText.text = currentHealth.ToString();
    }

    private void ReduceHealth()
    {
        currentHealth--;
        healthText.text = currentHealth.ToString();
        Debug.Log(currentHealth);
    }
}
