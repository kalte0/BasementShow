using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public static class DialogueHandler
{
    private static bool TextBoxShown = false; 
    //private static bool DialogueRunning = false;
//    private static Queue<string[]> dialogueQueue = new Queue<str ing[]>(); 
    private static TMP_Text text = null; 
    private static Image TextBoxImage = null; 
    private static Image ProfileImage = null; 
    private static Image HazelIcon = null;
    private static Image EleanorIcon = null;

    public static bool IsTextBoxShown() { 
        return TextBoxShown; 
    }


    static DialogueHandler() { 
        GameObject TextSystem = GameObject.Find("Canvas/TextSystem");
        TextBoxImage = TextSystem.transform.GetChild(0).GetComponent<Image>();  // must be a way to grab all of the children, but was having some issues with getting GetComponentsInChildren to work / iterating over it
        text = TextSystem.transform.GetChild(1).GetComponent<TMP_Text>(); 
        ProfileImage = TextSystem.transform.GetChild(2).GetComponent<Image>();
        EleanorIcon = TextSystem.transform.GetChild(3).GetComponent<Image>();
        HazelIcon = TextSystem.transform.GetChild(4).GetComponent<Image>();

        if (TextBoxImage == null) { 
            Debug.Log("TextBoxImage is null"); 
        }
        if (text == null) { 
            Debug.Log("text is null"); 
        }
        if (ProfileImage == null) { 
            Debug.Log("ProfileImage is null"); 
        }
    }

    /*public static IEnumerator RunDialogueFromQueue() { 
        DialogueRunning = true; 
        while (dialogueQueue.Count > 0) { 
            yield return Util.StartCoroutineFromStatic(ShowDialogue(dialogueQueue.Dequeue())); 
        }
        DialogueRunning = false;
    }*/
    // Start is called before the first frame update
    public static IEnumerator ShowDialogue(string[] dialogue) { 
        Debug.Log("Begin ShowDialogue()"); 
        /* if (DialogueRunning) { 
            dialogueQueue.Enqueue(dialogue); 
            yield break; 
        }*/
        ShowTextBox(); 
        foreach (var line in dialogue) { 
            Debug.Log("Line: " + line);
            if (line == "") { 
                RemoveTextBox(); 
            }
            else { 
                if (!TextBoxShown) { 
                    ShowTextBox(); 
                }
                if (line.Contains("H:")) { 
                    HazelIcon.enabled = true; 
                    EleanorIcon.enabled = false;
                    text.text = "Hazel: " + line.Substring(3); 
                }
                else if (line.Contains("E:")) { 
                    HazelIcon.enabled = false;
                    EleanorIcon.enabled = true;
                    text.text = "Eleanor: " + line.Substring(3); 
                }
                
            }
            yield return Util.StartCoroutineFromStatic(WaitUntilClick());
        }
        RemoveTextBox();
   }

    public static IEnumerator ActivateAfterDialogue(string[] dialogue, GameObject toActivate) { 
        Debug.Log("Begin ActivateAfterDialogue()");
        yield return Util.StartCoroutineFromStatic(ShowDialogue(dialogue)); // wait for dialogue sequence to finish, then
        toActivate.GetComponent<Image>().enabled = true ; // activate the object
    }

    public static IEnumerator RunAfterDialogue(string[] dialogue, System.Action action) { 
        Debug.Log("Begin RunAfterDialogue()");
        yield return Util.StartCoroutineFromStatic(ShowDialogue(dialogue)); // wait for dialogue sequence to finish, then
        action(); // run the action
    }

    public static void ShowTextBox() { 
        Debug.Log("Showing Text Box"); 
        TextBoxImage.enabled = true;
        ProfileImage.enabled = true;
        TextBoxShown = true; 
    }

    public static void RemoveTextBox() { 
        Debug.Log("Removing Text Box");
        text.text = ""; 
        TextBoxImage.enabled = false;
        ProfileImage.enabled = false;
        HazelIcon.enabled = false;
        EleanorIcon.enabled = false;
        TextBoxShown = false;
    }

    public static IEnumerator WaitUntilClick() { 
        yield return new WaitForSeconds(0.2f);
        while (!Input.GetMouseButtonDown(0)) { 
            yield return null; 
        }
    }
}
