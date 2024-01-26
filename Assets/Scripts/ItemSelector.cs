using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelector : MonoBehaviour
{
    [SerializeField] private List<GameObject> items = new List<GameObject>();

    private int currentItem = 0;

    private void Start()
    {
        DisableAllItems();
        EnableItem(currentItem);
    }

    private void EnableItem(int index)
    {
        items[index].SetActive(true);
    }

    private void DisableItem(int index)
    {
        items[index].SetActive(false);
    }

    private void DisableAllItems()
    {
        foreach (GameObject item in items)
        {
            item.SetActive(false);
        }
    }

    public void GoToNextItem()
    {
        if (currentItem == items.Count - 1) { return; }

        DisableItem(currentItem);
        currentItem++;
        EnableItem(currentItem);
    }

    public void GoToPreviousItem()
    {
        if (currentItem == 0) { return; }

        DisableItem(currentItem);
        currentItem--;
        EnableItem(currentItem);
    }
}
