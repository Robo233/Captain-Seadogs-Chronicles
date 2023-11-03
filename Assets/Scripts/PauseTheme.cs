using UnityEngine;

public class PauseTheme : MonoBehaviour
{
    [SerializeField] AudioSource theme;

    void Start()
    {
        theme.Play();
    }

}
