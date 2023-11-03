using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    [SerializeField] GameObject GameOverScreen;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject ReloadLastCheckpointButton;

    [SerializeField] Text CauseOfDeathText;

    [SerializeField] AudioSource audioSourceAmbient;
    [SerializeField] AudioSource audioSourceVolcano;
    [SerializeField] AudioSource PlayerDeathSound;

    [SerializeField] Objectives objectives;
    
    [SerializeField] Vector3 CheckPoint1;
    public Vector3 CheckPointBetween1and2;
    public Vector3 CheckPoint2;
    public Vector3 CheckPoint3;
    public Vector3 CheckPoint4;
    public Vector3 CheckPoint5;

    public Vector3 LastCheckpoint;
    public Quaternion LastRotation;

    [SerializeField] Quaternion Rotation1;
    public Quaternion RotationBetween1and2;
    public Quaternion Rotation2;
    public Quaternion Rotation3;
    public Quaternion Rotation4;
    public Quaternion Rotation5;

    void Start(){

      LastCheckpoint = CheckPoint1;
      LastRotation = Rotation1;
    }
    
  public void DeathFunction(string CauseOfDeath)
    {
   
            GameOverScreen.SetActive(true);
            audioSourceAmbient.Stop();
            Cursor.visible = true;
            PlayerDeathSound.Play();
            CauseOfDeathText.text = CauseOfDeath;
            Player.transform.position = new Vector3(58.9526f,1.797986f,83.2887f);
            gameObject.SetActive(false);
            if(objectives.PlayerWasInCave){
              ReloadLastCheckpointButton.SetActive(true);
            }
     
    }

     void ReloadLastCheckPoint(){

      GameOverScreen.SetActive(false);
      Player.transform.position = LastCheckpoint;
      Player.transform.rotation = LastRotation;
     
      Cursor.visible = false;

       if ((Player.transform.position.x > -333 && Player.transform.position.x < 1125) && (Player.transform.position.z > 800 && Player.transform.position.z < 2150))
        {
            audioSourceAmbient.Play(); 
        }
        else
        {
            audioSourceVolcano.Play(); 
        }

    }

}
