using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : MonoBehaviour
{
    private string[] Dialogue = { 
        "E: (I don't need to use this right now.)" 
    };

    public void OnMouseDown() { 
        Debug.Log("Toilet Clicked"); 
        if (!DialogueHandler.IsTextBoxShown() && !Util.PopUpShown) { 
            StartCoroutine(DialogueHandler.ShowDialogue(GetDialogue())); 
        }
    } 
    public string[] GetDialogue() { 
        return Dialogue; 
    }
}
