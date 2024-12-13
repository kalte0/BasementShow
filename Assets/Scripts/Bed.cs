using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    private string[] Dialogue = { 
        "H: I didn't realize that you moonlit as a fairytale princess.",
        "E: I don't. I just like to sleep in a nice bed.",
        "H: Of course. You got anything useful under there?",
        "E: Let's see..."
    };

    public GameObject ShowWhenClicked = null;  
    public void OnMouseDown() { 
        Debug.Log("Bed Clicked"); 
        if (!DialogueHandler.IsTextBoxShown() && !Util.PopUpShown) { 
            StartCoroutine(DialogueHandler.ActivateAfterDialogue(GetDialogue(), ShowWhenClicked)); 
        }
    } 
    public string[] GetDialogue() { 
        return Dialogue; 
    }
}
