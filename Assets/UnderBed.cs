using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UnderBed : MonoBehaviour
{

    public GameObject ShowWhenClicked = null; 
    private string[] Dialogue = { 
        "E: Oh-- wait, no-- don't touch that! That's--", 
        "H: Heehee!! It's so cute!!",
        "E: Eugh.. I'm aware.",
        "H: If we want to solve this puzzle, we have to--",
        "E: Yeah, yeah, whatever. Let's just get this over with."
    };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Image>().enabled) { 
            GameObject.Find("Canvas/Background").GetComponent<Image>().enabled = true;
            Util.PopUpShown = true; 
        }
        else { // not enabled.
            GameObject.Find("Canvas/Background").GetComponent<Image>().enabled = false;
        }

        if (Input.GetMouseButtonDown(0)) { 
            if (!DialogueHandler.IsTextBoxShown() && this.GetComponent<Image>().enabled && !GameObject.Find("Canvas/PopUps/Box").GetComponent<Image>().enabled) { 
                Debug.Log("Clicked while UnderBed up"); 
                StartCoroutine(DialogueHandler.ActivateAfterDialogue(GetDialogue(), ShowWhenClicked)); 
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !DialogueHandler.IsTextBoxShown() && !GameObject.Find("Canvas/PopUps/Box").GetComponent<Image>().enabled) { 
            GameObject.Find("Canvas/PopUps/UnderBed").GetComponent<Image>().enabled = false;
            GameObject.Find("Canvas/Background").GetComponent<Image>().enabled = false;
            Util.PopUpShown = false; 
        }
    }

    private string[] GetDialogue() { 
        return Dialogue; 
    }
}
