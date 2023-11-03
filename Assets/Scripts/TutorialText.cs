using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour
{
   
    public Text Tutorial;

    public void TutorialTextFunction(string TutorialText){
    
    Tutorial.text = TutorialText;
    
    }

}
