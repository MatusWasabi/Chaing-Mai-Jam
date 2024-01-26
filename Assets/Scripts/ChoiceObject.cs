using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class ChoiceObject : MonoBehaviour
{ 
    [SerializeField] private CombinationBar combinationBar;
    public void AddToCombinationSlot()
    {
        combinationBar.AddToSlot(gameObject.name);
    }
}
