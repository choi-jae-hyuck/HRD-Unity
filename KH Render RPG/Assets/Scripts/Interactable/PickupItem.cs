using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactable
{
    public Item item;
    public override void Interact()
    {
        SelectItem();
    }

    void SelectItem()
    {
        Debug.Log("item Get");
        bool isSelected = Inventory.instance.Add(item);
        if (isSelected)
            Destroy(this.gameObject);
    }
}
