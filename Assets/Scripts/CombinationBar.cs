using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CombinationBar : MonoBehaviour
{

    [SerializeField] private Button firstSlot;

    [SerializeField] private Button secondSlot;
    
    [SerializeField] private string[] slots = new string[2];

    [SerializeField] private List<Combination> angryCombinations = new List<Combination>();
    
    private List<Combination> usedAngryFormular = new List<Combination>();

    [SerializeField] private TextMeshProUGUI moodText;

    //public delegate void BeAngry();

    public static event Action OnBeAngried;
    
    public void AddToSlot(string thingToAdd, Sprite newSprite)
    {
        int index = 0;
        foreach (string slot in slots)
        {
            if (slot == "")
            {
                slots[index] = thingToAdd;
                UpdateSlots();
                if (index == 0)
                {
                    firstSlot.image.sprite = newSprite;
                }

                if (index == 1)
                {
                    secondSlot.image.sprite = newSprite;
                }
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
        foreach (var combination in angryCombinations)
        {
            if (combination.IsSameRecipe(slots[0], slots[1]))
            {
                Debug.Log("Found " + combination.ToString());
                OnBeAngried?.Invoke();
                ClearAllSlots();
                angryCombinations.Remove(combination);
                return;
            }
        }

        
        foreach (var combination in usedAngryFormular)
        {
            if (combination.IsSameRecipe(slots[0], slots[1]))
            {
                ClearAllSlots();
                return;
            }
        }
        ClearAllSlots();
    }
    

    public void ClearFromSlot(int index)
    {
        slots[index] = "";
        if (index == 0)
        {
            firstSlot.image.sprite = null;
        }

        if (index == 1)
        {
            secondSlot.image.sprite = null;
        }
        UpdateSlots();
    }
    
    private void ClearAllSlots()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = "";
        } 
        firstSlot.image.sprite = null;
        secondSlot.image.sprite = null;
        UpdateSlots();
    }
    
    

}
