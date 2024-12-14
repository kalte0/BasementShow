using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;

public class Letter : MonoBehaviour
{
    private string[] Dialogue = { 
        "H: A letter? Kind of looks like your handwriting...",
        "E: ...",
        "H: What?",
        "E: Nothing. Just... give it here.",
        "H: Oh wow-- this is kind of... intense.", 
        "E: Well, that describes my mother.", 
        "H: Do you think that's our secret to getting out..?", 
        "E: Caving to her guilt-trip? I hope not."
    };

    public GameObject ShowWhenClicked = null;  
    public void OnMouseDown() { 
        Debug.Log("Letter Clicked"); 
        if (!DialogueHandler.IsTextBoxShown() && !Util.PopUpShown) {
            GameObject.Find("Canvas/Background").GetComponent<Image>().enabled = true;
            ShowWhenClicked.GetComponent<Image>().enabled = true;
            StartCoroutine(DialogueHandler.ShowDialogue(GetDialogue())); 
        }
    } 
    public string[] GetDialogue() { 
        return Dialogue; 
    }
}
