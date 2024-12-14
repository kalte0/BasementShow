using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Eleanor
{
    private static EleanorMovement em = GameObject.Find("Eleanor").GetComponent<EleanorMovement>(); 
    private static int rotation = 2; // initially, looking forward. 
    // Start is called before the first frame update
    public static bool moving = false; 

    public static int GetRotation() { 
        return rotation; 
    }

    public static void SetRotation(int newRotation) { 
        rotation = newRotation; 
    }
}
