using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    private string[] Dialogue = { 
        "E: It's February. That's... weird.",
        "H: What? Why is that weird?",
        "E: This place looks just like my high school bedroom. So-- I should be at school. Not here...",
        "E: ...",
        "E: Let's keep looking around." 
    };

    public void OnMouseDown() { 
        Debug.Log("Calendar Clicked"); 
        if (!DialogueHandler.IsTextBoxShown() && !Util.PopUpShown) { 
            StartCoroutine(DialogueHandler.ShowDialogue(GetDialogue())); 
        }
    } 
    public string[] GetDialogue() { 
        return Dialogue; 
    }
}
