using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazel : MonoBehaviour
{
    public string[] Dialogue = { 
        "H: What's up?" 
    };

    public Vector3 position; 

    public void Start() { 
        position = this.transform.position; 
    }

    public void Update() { 
        HazelPositioner.Update(); 
        position = HazelPositioner.GetPosition();
        this.transform.position = position;
    }

    public void OnMouseDown() { 
        Debug.Log("Hazel Clicked"); 
        if (!DialogueHandler.IsTextBoxShown() && !Util.PopUpShown) { 
            StartCoroutine(DialogueHandler.ShowDialogue(GetDialogue())); 
        }
    }

    public string[] GetDialogue() { 
        return Dialogue; 
    }   
}
