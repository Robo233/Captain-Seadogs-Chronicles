using UnityEngine;

public class PauseMenu : MonoBehaviour
{
   
    [SerializeField] GameObject PauseMenuScreen;
    [SerializeField] GameObject OptionsMenuObject;
    [SerializeField] GameObject GameOverScreen;
    [SerializeField] GameObject MissionCompleteScreen;
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject audioSourceObject;
    [SerializeField] GameObject Inventory;
    [SerializeField] GameObject InGameUi;

    [SerializeField] GameObject[] Enemies;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource audioSource2;

    [SerializeField] Transform Player;
    
    [SerializeField] AudioClip VolcanoAmbient;
    [SerializeField] AudioClip IslandAmbient;

    [SerializeField] bool isVolcanoSoundPlayed;
    

    void Start()
    {
        
        if ((Player.transform.position.x > -333 && Player.transform.position.x < 1125) && (Player.transform.position.z > 800 && Player.transform.position.z < 2150))
        {
            isVolcanoSoundPlayed = true;
        }
        else
        {
            isVolcanoSoundPlayed = false;
        }

        Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        }

    void Update()
    {
        if (OptionsMenuObject.activeSelf == false && GameOverScreen.activeSelf == false && MainMenu.activeSelf == false && MissionCompleteScreen.activeSelf == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(!Inventory.activeSelf){
               
                if (!PauseMenuScreen.activeSelf)
                {
                    StopGameFunction();
                    

                }
                else
                {
                    ResumeFunction();
                    

                }
                }
            }
        }
        else if (OptionsMenuObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
               
                OptionsMenuObject.SetActive(false);
            }
        }

        SetVolcanoAmbient();

    }
 
    public void ResumeFunction()
    {
        InGameUi.SetActive(true);
        PauseMenuScreen.SetActive(false);
        MainMenu.SetActive(false);
        MissionCompleteScreen.SetActive(false);
        audioSource.Play();
        audioSource2.Stop();
        Cursor.visible = false;
        Time.timeScale = 1;
          for(int i=0;i<Enemies.Length;i++){
            Enemies[i].GetComponent<EnemyController>().enabled = true;
        }
    }
    public void StopGameFunction()
    {
        PauseMenuScreen.SetActive(true); 
        audioSource.Stop();
        audioSource2.Play();
        Cursor.visible = true;
        Time.timeScale = 0;
        for(int i=0;i<Enemies.Length;i++){
            Enemies[i].GetComponent<EnemyController>().enabled = false;
        }
    }

    public void SetVolcanoAmbient()
    {
      

        if ((Player.transform.position.x > -333 && Player.transform.position.x < 1125) && (Player.transform.position.z > 800 && Player.transform.position.z < 2150))
        {
            audioSource.GetComponent<AudioSource>().clip = VolcanoAmbient;
            if (isVolcanoSoundPlayed && audioSourceObject.activeSelf)
            {
                audioSource.Play(); 
                isVolcanoSoundPlayed = false;
            }
            
        }
        else
        {
            audioSource.GetComponent<AudioSource>().clip = IslandAmbient;
            if (!isVolcanoSoundPlayed && audioSourceObject.activeSelf)
            {
                audioSource.Play();
                isVolcanoSoundPlayed = true;
            }
        }
     
        
    }

}


