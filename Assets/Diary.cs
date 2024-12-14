using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;

public class Diary : MonoBehaviour
{
    private string[] LockedDialogue = { 
        "H: A diary? I didn't know you were the type to keep one.",
        "E: It was a long time ago.", 
        "H: Ah, well-- looks like it's locked. Which means you're safe from me being nosy.",
        "E: Am I *ever* truly safe from that?",
        "H: Ha!"
    };

    private string[] UnlockedDialogue = { 
        "E: Now we've got the key, let's see what's inside.",
        "H: ...",
        "E: ...",
        "H: It's blank.",
        "E: I definitely remember writing in this.", 
        "H: ...",
        "H: Do you think... from that letter. I mean--",
        "E: What?", 
        "H: Is this part of the puzzle?", 
        "E: How?", 
        "H: The letter *said* to... think on what you'd done. Maybe you're supposed to write it down here?",
        "H: I mean... Why were you grounded anyways?",
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
        if (Inventory.Contains("Key")) { 
            return UnlockedDialogue; 
        } else { 
            return LockedDialogue; 
        }
    }
}
