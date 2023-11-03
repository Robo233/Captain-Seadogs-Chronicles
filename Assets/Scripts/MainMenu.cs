using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject MainMenuObject;
    [SerializeField] GameObject GameOverMenuObject;
    [SerializeField] GameObject Objective;

    [SerializeField] AudioSource audioSource2;

    [SerializeField] Transform Player;

    void MainMenuOn()
    {
        MainMenuObject.SetActive(true);
        GameOverMenuObject.SetActive(false);
        Player.position = new Vector3(59, (float)2, 90);
        Cursor.visible = true;
        audioSource2.Play();
       
    }

    void QuitGame(){
        Application.Quit();
       
    }
}
