using UnityEngine;

public class BoatController : MonoBehaviour
{
   [SerializeField] GameObject Player;
   [SerializeField] GameObject Hat;
   [SerializeField] GameObject Boat;
  

   [SerializeField] Camera PlayerCamera;
   [SerializeField] Camera BoatCamera;

   public bool isMounted = false;

   [SerializeField] TutorialText tutorialText;

   Vector3 PlayerOriginalPosition;


   public void Board(){
       
     if(!isMounted){
      if(Input.GetKeyDown(KeyCode.E)){
         isMounted = true;
      }
     }

     else{
         if(Input.GetKeyDown(KeyCode.E)){
         isMounted = false;
      }
     }


      if(!isMounted){
        
          tutorialText.TutorialTextFunction("Press E to mount boat");
          Player.GetComponent<CharacterController>().enabled = true;
          PlayerCamera.enabled = true;
          PlayerCamera.GetComponent<CameraController>().enabled = true;
          BoatCamera.GetComponent<CameraController>().enabled = false;
          BoatCamera.enabled = false;
          Boat.GetComponent<BoatMovement>().enabled = false;
          Player.transform.parent = null;
          Player.GetComponentInChildren<Animator>().SetBool("isSitting", false);
          Player.GetComponent<PlayerMovement>().isMounted = false;
          Hat.transform.localPosition = new Vector3(0,2.08f,0);
      }
      else{
         tutorialText.TutorialTextFunction(string.Empty);
         Player.GetComponent<CharacterController>().enabled = false;
         PlayerCamera.enabled = false;
         PlayerCamera.GetComponent<CameraController>().enabled = false;
         BoatCamera.GetComponent<CameraController>().enabled = true;
         BoatCamera.enabled = true;
         Boat.GetComponent<BoatMovement>().enabled = true;
         PlayerOriginalPosition = Player.transform.position;
         Player.transform.SetParent(Boat.transform, false);
         Player.transform.localPosition = new Vector3(-0.015f,0.636f,-3.232f);
         Player.GetComponentInChildren<Animator>().SetBool("isSitting", true);
         Player.GetComponent<PlayerMovement>().isMounted = true;
         Player.transform.localRotation = new Quaternion(0,0,0,0);
         Hat.transform.localPosition = new Vector3(0,1.604f,0);
      }
      
   }
}
