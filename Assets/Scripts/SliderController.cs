using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    int progress = 0;

    [SerializeField] Slider slider;

    void UpdateProgress()
    {
        
        progress--;
        slider.value = progress;
    }
   
}
