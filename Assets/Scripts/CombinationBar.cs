using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CombinationBar : MonoBehaviour
{

    [SerializeField] private Button firstSlot;

    [SerializeField] private Button secondSlot;
    // Start is called before the first frame update

    [FormerlySerializedAs("slot")] [SerializeField]
    private string[] slots = new string[2];

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



}
