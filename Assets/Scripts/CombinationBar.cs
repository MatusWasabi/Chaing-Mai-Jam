using System;
using System.Collections.Generic;

using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CombinationBar : MonoBehaviour
{
    [SerializeField] private Button firstSlot;
    [SerializeField] private Button secondSlot;
    
    [SerializeField] private Combination playerCombination = new Combination();
    [SerializeField] private List<Combination> angryCombinations = new List<Combination>();
    private List<Combination> usedAngryFormular = new List<Combination>();

    [SerializeField] private TextAnimation DialogText;
    
    public static event Action OnBeAngried;
    
    public void AddToSlot(string thingToAdd, Sprite newSprite)
    {
        if (playerCombination.recipe1 == "")
        {
            playerCombination.recipe1 = thingToAdd;
            firstSlot.image.sprite = newSprite;
            UpdateSlots();
            return;
        }

        if (playerCombination.recipe2 == "")
        {
            playerCombination.recipe2 = thingToAdd;
            secondSlot.image.sprite = newSprite;
            UpdateSlots();
            return;
        }
        
        
    }
    

    private void UpdateSlots()
    {
        firstSlot.GetComponentInChildren<TextMeshProUGUI>().text = playerCombination.recipe1;
        secondSlot.GetComponentInChildren<TextMeshProUGUI>().text = playerCombination.recipe2;
    }

    public void CheckAngry()
    {
        foreach (var combination in angryCombinations)
        {
            if (combination.IsSameRecipe(playerCombination.recipe1, playerCombination.recipe2))
            {
                OnBeAngried?.Invoke();
                DialogText.ChangeText(combination.GetWord(0));
                ClearAllSlots();
                angryCombinations.Remove(combination);
                return;
            }
        }
        
        foreach (var combination in usedAngryFormular)
        {
            if (combination.IsSameRecipe(playerCombination.recipe1, playerCombination.recipe2))
            {
                ClearAllSlots();
                return;
            }
        }
        ClearAllSlots();
    }

    public void ClearFromSlot(int index)
    {
        if (index == 0)
        {
            playerCombination.recipe1 = "";
            firstSlot.image.sprite = null;
        }

        if (index == 1)
        {
            playerCombination.recipe2 = "null";
            secondSlot.image.sprite = null;
        }
        UpdateSlots();
    }
    
    private void ClearAllSlots()
    {
        playerCombination.recipe1 = "";
        playerCombination.recipe2 = "";
        
        firstSlot.image.sprite = null;
        secondSlot.image.sprite = null;
        UpdateSlots();
    }
    
    

}
