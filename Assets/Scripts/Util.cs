using System.Collections;
using System.Collections.Generic;
using System; 
using UnityEngine.UI; 
using UnityEngine;
using TMPro;

public static class Util
{
    public class CoroutineRunner : MonoBehaviour { }
    public static CoroutineRunner cRunner = null; 
    public static bool PopUpShown = false; 
    public static GameObject QuestionDisplay = GameObject.Find("Eleanor").GetComponent<EleanorMovement>().QuestionDisplay;
    public static TMP_Text QuestionText = null;
    public static GameObject Option1 = null;
    public static GameObject Option2 = null;

    static Util() { 
        GameObject mngr = GameObject.Find("Eleanor"); 
        mngr.AddComponent<CoroutineRunner>();  
        cRunner = mngr.GetComponent<CoroutineRunner>();
        QuestionText = QuestionDisplay.GetComponentInChildren<TMP_Text>();
    }

    public static IEnumerator StartCoroutineFromStatic(IEnumerator coroutine) { 
        if (cRunner == null) { 
            Debug.Log("cRunner is null");
        }
        if (coroutine == null) { 
            Debug.Log("coroutine is null"); 
        } 
        yield return cRunner.StartCoroutine(coroutine); 
    }

    public static IEnumerator test() { 
        Debug.Log("Util test");
        yield return null; 
    }

    public static void HidePopUps() { 
        CanvasRenderer[] PopUps = GameObject.Find("Canvas/PopUp").GetComponentsInChildren<CanvasRenderer>();   
        foreach (CanvasRenderer PopUp in PopUps) { 
            PopUp.gameObject.SetActive(false); 
        }
    }

    public static void ShowQuestion(string question, string question1, string question2, Action result1, Action result2) { 
        QuestionDisplay.SetActive(true); 
        QuestionText.text = question;
        TMP_Text[] OptionTexts = QuestionDisplay.GetComponentsInChildren<TMP_Text>();
        OptionTexts[1].text = question1;
        OptionTexts[2].text = question2;

        Button[] OptionButtons = QuestionDisplay.GetComponentsInChildren<Button>();

        OptionButtons[0].onClick.AddListener(() => { 
            result1(); 
        });
        OptionButtons[1].GetComponent<Button>().onClick.AddListener(() => { 
            result2(); 
        });
        // does this keep adding listeners? Will it keep doingthe previous thing? Doesn't matter for now, but...
    }

    public static void HideQuestions() { 
        QuestionDisplay.SetActive(false);
    }
} 
 