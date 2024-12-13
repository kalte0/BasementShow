using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private static List<string> inventory = new List<string>();
    // Start is called before the first frame update

    public void ShowInventory(string[] items) { 
        transform.Find("Slot/Item").GetComponent<Image>().enabled = true; // Resources.Load<Sprite>("Sprites/" + items[0]
    }
}
