using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine; 

public class EscapeButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() => {
            if (Util.PopUpShown) {
                Util.HidePopUps();
            } else {
                Util.ShowQuestion("Would you like to quit the game? You will lose progress thus far!", "Yes (leave)", "No (stay)", () => {
                    //Application.Exit();
                },
                () => { 
                    Util.HideQuestions(); 
                });
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
