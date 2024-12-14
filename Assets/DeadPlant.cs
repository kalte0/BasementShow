using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    private string[] Dialogue = { 
        "E: (It's dead. Likely of draught.)" 
    };

    public void OnMouseDown() { 
        Debug.Log("DeadPlant Clicked"); 
        if (!DialogueHandler.IsTextBoxShown() && !Util.PopUpShown) { 
            StartCoroutine(DialogueHandler.ShowDialogue(GetDialogue())); 
        }
    } 
    public string[] GetDialogue() { 
        return Dialogue; 
    }
}
