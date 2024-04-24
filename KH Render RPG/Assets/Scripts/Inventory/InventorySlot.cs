using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;
    public Image icon;
    public Button xbutton;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        xbutton.interactable = true;

    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        xbutton.interactable = false;
    }

    public void OnXButtonClicked()
    {
        Inventory.instance.Remove(item);
    }

    public void OnItemButtonClicked()
    {
        if(item != null)
        {
            item.Use();
        }
    }
}
