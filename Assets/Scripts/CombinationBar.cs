using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CombinationBar : MonoBehaviour
{

    [SerializeField] private Button firstSlot;

    [SerializeField] private Button secondSlot;

    [SerializeField] private string[] slots = new string[2];

    [SerializeField] private string[] angryCombination0 = new string[2];
    [SerializeField] private string[] angryCombination1 = new string[2];
    [SerializeField] private string[] angryCombination2 = new string[2];
    [SerializeField] private string[] angryCombination3 = new string[2];
    
    private List<string[]> angryFormular = new List<string[]>();
    private List<string[]> usedAngryFormular = new List<string[]>();

    [SerializeField] private TextMeshProUGUI moodText;

    public delegate void BeAngry();

    public static event BeAngry OnBeAngried;
    
    private void Start()
    {
        angryFormular.Add(angryCombination0);
        angryFormular.Add(angryCombination1);
        angryFormular.Add(angryCombination2);
        angryFormular.Add(angryCombination3);
    }

    public void AddToSlot(string thingToAdd)
    {
        int index = 0;
        foreach (string slot in slots)
        {
            if (slot == "")
            {
                slots[index] = thingToAdd;
                UpdateSlots();
                return;     
            }
            index += 1;
        }
        
    }

    private void UpdateSlots()
    {
        firstSlot.GetComponentInChildren<TextMeshProUGUI>().text = slots[0];
        secondSlot.GetComponentInChildren<TextMeshProUGUI>().text = slots[1];
    }

    public void CheckAngry()
    {
        foreach (var combination in angryFormular)
        {
            if (CheckIfSameCombination(combination))
            {
                Debug.Log("Found things to be angried");
                OnBeAngried();
                ChangeMood();
                ClearSlot();
                angryFormular.Remove(combination);
                usedAngryFormular.Add(combination);
                return;
            }
        }

        
        foreach (var combination in usedAngryFormular)
        {
            if (CheckIfSameCombination(combination))
            {
                Debug.Log("You have used this combination");
                ClearSlot();
                return;
            }
        }
        
        
        ClearSlot();
    }

    private void ChangeMood()
    {
        moodText.text = "Angry!";
    }

    private void ClearSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = "";
        } 
        UpdateSlots();
    }

    private bool CheckIfSameCombination(string[] combination)
    {
        return Enumerable.SequenceEqual(slots.OrderBy(t => t), combination.OrderBy(t => t));
    }
    

}
