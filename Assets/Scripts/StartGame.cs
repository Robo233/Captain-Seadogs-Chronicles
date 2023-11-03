using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject PauseMenuScreen;
    [SerializeField] GameObject audioSourceObject;
    [SerializeField] GameObject InGameUi;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource audioSource2;

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] CameraController cameraController;

    bool isPaused;
    [SerializeField] bool isDead;

    void ReStartGameFunction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
     
 
    }
    void StartGameFunction() { 
    
        MainMenu.SetActive(false);
        PauseMenuScreen.SetActive(false);
        audioSource2.Stop();
        Cursor.visible = false;
        audioSourceObject.SetActive(true);
        playerMovement.enabled = true;
        cameraController.enabled = true;
        InGameUi.SetActive(true);
    }



}
