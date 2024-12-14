using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;

public class DiaryVisual : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Image>().enabled) { 
            GameObject.Find("Canvas/Background").GetComponent<Image>().enabled = true;
        }
        else { // not enabled.
            GameObject.Find("Canvas/Background").GetComponent<Image>().enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !DialogueHandler.IsTextBoxShown()) { 
            GameObject.Find("Canvas/PopUps/Diary").GetComponent<Image>().enabled = false;
            GameObject.Find("Canvas/Background").GetComponent<Image>().enabled = false;
        }
    }
}
