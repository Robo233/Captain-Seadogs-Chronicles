using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] GameObject OptionsMenuObject;
    [SerializeField] GameObject InGameUi;

    void OptionsMenuOn( )
    {
        
        OptionsMenuObject.SetActive(true);
      
    }
    void OptionsMenuOff()
    {
        OptionsMenuObject.SetActive(false);
        InGameUi.SetActive(false);
        
    }
}