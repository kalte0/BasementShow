using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    private string[] EleanorFlick = { 
        "E: Flick."
    };
    private string[] HazelFlick = { 
        "H: Flick."
    }; 

    public void OnMouseDown() { 
        Debug.Log("LightSwitch Flicked"); 
        if (!DialogueHandler.IsTextBoxShown() && !Util.PopUpShown) { 
            StartCoroutine(DialogueSequence());
        }
    } 
    public string[] GetDialogue() { 
        return new string[] {EleanorFlick[0], HazelFlick[0]}; 
    }

    public void FlickSwitch() { 
        GameObject Background = GameObject.Find("Canvas/Background"); 
        Background.GetComponent<Image>().enabled = !Background.GetComponent<Image>().enabled; // toggle background layer. 
        Background.GetComponent<Image>().color = new Color(0, 0, 0, 0.5f); // make it a bit darker.
    }

    public IEnumerator DialogueSequence() { 
        yield return StartCoroutine(DialogueHandler.RunAfterDialogue(new[] {""}, FlickSwitch)); 
        yield return StartCoroutine(DialogueHandler.RunAfterDialogue(EleanorFlick, FlickSwitch)); 
        StartCoroutine(DialogueHandler.ShowDialogue(HazelFlick));
    }
}
