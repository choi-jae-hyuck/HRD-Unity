﻿using System.Collections;
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
        // Debug.Log("item Get");
        bool isSelected = Inventory.instance.Add(item);
        if (isSelected)
        {
            if (item.audioClip != null)
            {
                AudioManager.instance.source.clip = item.audioClip;
                AudioManager.instance.source.Play();
            }

            Destroy(this.gameObject);
        }
    }
}
