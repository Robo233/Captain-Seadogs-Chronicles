using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    List<int> widths = new List<int>() { 568, 960, 1280, 1920 };
    List<int> heights = new List<int>() { 320, 540, 800, 1080 };

    [SerializeField] Slider volumeSlider;

    void SetScreenSize(int index)
    {
        bool fullscreen = Screen.fullScreen;
        int width = widths[index];
        int height = heights[index];
        Screen.SetResolution(width, height, fullscreen);
    }

    void SetFullscreen(bool _fullscreen)
    {
        Screen.fullScreen = _fullscreen;
    }

    void Awake()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            SetVolume(PlayerPrefs.GetFloat("Volume"));
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        }
    }

    void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
