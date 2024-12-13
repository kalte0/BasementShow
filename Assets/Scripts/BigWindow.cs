using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigWindow : MonoBehaviour
{
    private string[] Dialogue = { 
        "H: *To herself:* Baby it's cold outside..." 
    };

    public void OnMouseDown() { 
        Debug.Log("Window Clicked"); 
        if (!DialogueHandler.IsTextBoxShown() && !Util.PopUpShown) { 
            StartCoroutine(DialogueHandler.ShowDialogue(GetDialogue())); 
        }
    } 
    public string[] GetDialogue() { 
        return Dialogue; 
    }
}
