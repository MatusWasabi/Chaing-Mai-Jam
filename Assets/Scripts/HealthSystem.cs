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

    [SerializeField] private GameObject endScreen;
    
    
    private void Start()
    {
        CombinationBar.OnBeAngried += ReduceHealth;
        currentHealth = startHealth;
        healthText.text = currentHealth.ToString();
    }

    private void ReduceHealth()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            StartCoroutine(EndGame());
        }
    }

    private void OnDestroy()
    {
        CombinationBar.OnBeAngried -= ReduceHealth;
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(6f);
        endScreen.SetActive(true);
    }
}
