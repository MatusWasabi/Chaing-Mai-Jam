using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ChoiceObject : MonoBehaviour
{ 
    [SerializeField] private CombinationBar combinationBar;
    private Sprite _sprite;

    private void Awake()
    {
        _sprite = gameObject.GetComponent<Image>().sprite;
    }

    public void AddToCombinationSlot()
    {
        combinationBar.AddToSlot(gameObject.name, gameObject.GetComponent<Image>().sprite);
    }
    
    
}
