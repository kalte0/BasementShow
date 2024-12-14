using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;

public static class Inventory
{

    private static List<string> inventory = new List<string>();
    // Start is called before the first frame update

    public static bool Contains(string item) { 
        return inventory.Contains(item); 
    }
    
    public static void AddItem(string item) { 
        inventory.Add(item); 
        GameObject.Find("Canvas/Inventory/Slot/Key").GetComponent<Image>().enabled = true; 
    }

    public static void RemoveItem(string item) {
        inventory.Remove(item); 
    }

    public static void Show() { 
        Debug.Log("Inventory: " + string.Join(", ", inventory.ToArray()));
        GameObject.Find("Canvas/Inventory").GetComponent<InventoryUI>().ShowInventory(inventory.ToArray());
    }
}
