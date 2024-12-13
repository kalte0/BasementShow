using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    private string[] Dialogue = { 
        "H: That's a cute nightlight!",
        "E: Thanks."
    };

    public void OnMouseDown() { 
        Debug.Log("Mushroom Clicked"); 
        if (!DialogueHandler.IsTextBoxShown() && !Util.PopUpShown) { 
            StartCoroutine(DialogueHandler.ShowDialogue(GetDialogue())); 
        }
    } 
    public string[] GetDialogue() { 
        return Dialogue; 
    }
}
