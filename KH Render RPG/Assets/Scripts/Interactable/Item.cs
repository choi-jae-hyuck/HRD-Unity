using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{
    public override void Interact()
    {
        SelectItem();
    }

    void SelectItem()
    {
        Debug.Log("item");
    }

}
