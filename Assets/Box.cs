using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Box : MonoBehaviour
{
    public bool KeyGot = false; 
    private string[] Dialogue = { 
        "H: To be honest, I was expecting something far more scandalous.",
        "E: Please, like I'd just keep my--",
        "H: ..?",
        "E: *illicit things* In a box under my bed. Amateur hour.",
        "H: Is that Winona Ryder?", 
        "E: Oh look, a key!"
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
            if (!KeyGot) { 
                transform.GetChild(0).GetComponent<Image>().enabled = true; 
            }
            else { 
                transform.GetChild(0).GetComponent<Image>().enabled = false;
            }
            Util.PopUpShown = true; 
        }
        else { // not enabled.
            GameObject.Find("Canvas/Background").GetComponent<Image>().enabled = false;
        }

        

        if (Input.GetMouseButtonDown(0)) { 
            if (!DialogueHandler.IsTextBoxShown() && this.GetComponent<Image>().enabled && !KeyGot) { 
                Debug.Log("Clicked while Box up and key present."); 
                StartCoroutine(DialogueHandler.RunAfterDialogue(GetDialogue(), removeKey)); 
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !DialogueHandler.IsTextBoxShown()) { 
            GameObject.Find("Canvas/PopUps/Box").GetComponent<Image>().enabled = false; 
            GameObject.Find("Canvas/PopUps/Box/Key").GetComponent<Image>().enabled = false;
        }
    }

    public string[] GetDialogue() { 
        return Dialogue; 
    }

    public void removeKey() { 
        KeyGot = true; 
        Inventory.AddItem("Key"); 
    }
}
