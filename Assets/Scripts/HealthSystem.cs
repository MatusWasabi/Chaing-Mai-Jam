using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int startHealth;
    [SerializeField] private int currentHealth;

    private void Start()
    {
        CombinationBar.OnBeAngried += ReduceHealth;
        currentHealth = startHealth;
    }

    private void ReduceHealth()
    {
        currentHealth--; 
        Debug.Log(currentHealth);
    }
}
