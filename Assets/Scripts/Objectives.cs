using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Objectives : MonoBehaviour
{
    [SerializeField] GameObject Objective;
    [SerializeField] GameObject ObjectiveImage;
    [SerializeField] GameObject EnemyRadar;
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject OpenedChest;
    [SerializeField] GameObject MissionCompleteScreen;
    [SerializeField] GameObject Gold;
    [SerializeField] GameObject Ring;
    [SerializeField] GameObject MissionCompleteText;
    GameObject SceneLoader;

    [SerializeField] Text Objective1;
    

    [SerializeField] string Text1;
    [SerializeField] string Text2;
    [SerializeField] string Text3;

    bool EnemiesAreDead;
    bool isMissionCompleted;
    bool isMissionCompleted2;
    bool ismissionCompleteSkipped;
    [SerializeField] bool VolcanoMissionStarted;
    public bool PlayerWasInCave;

    int EnemyCount;
    int NumberOfTimesEnterWasPressed;
    int NumberOfTimesEnterWasPressed2;

    GameObject[] Enemies;
    GameObject[] Deads;
    [SerializeField] GameObject[] ObjectivesArr;

    [SerializeField] List<GameObject> InventoryList = new List<GameObject>(14);

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] BoatMovement boatMovement;
    [SerializeField] CameraController cameraController;

    [SerializeField] Animator PlayerAnimator;

    [SerializeField] AudioSource MissionCompleteSound;


    void Start()
    {
        Objective1.text = Text1;
        NumberOfTimesEnterWasPressed = 0;

        if (Objective.activeSelf)
        {
            EnemiesAreDead = false;
            Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            EnemyCount = Enemies.Length;
        }
        SceneLoader = gameObject;
        InventoryList = SceneLoader.GetComponent<OpenInventory>().InventoryList;
        isMissionCompleted = false;
    }

    void Update()
    {
        if (!MainMenu.activeSelf)
        {
            ChangeText();
            
            Deads = GameObject.FindGameObjectsWithTag("Dead");
            AreEnemiesDead();
            
        }

        if(ObjectiveImage.activeSelf){
            gameObject.GetComponent<TutorialText>().TutorialTextFunction("Press Enter to continue!");
        }
        else{
            if(gameObject.GetComponent<TutorialText>().Tutorial.text!="Press E to buy or sell"){
       
            }
        }

            if (Input.GetKeyDown(KeyCode.Return) && VolcanoMissionStarted && !PlayerWasInCave)
        {
            ObjectiveImage.SetActive(false);
            playerMovement.enabled = true;
            boatMovement.enabled = true;
            cameraController.enabled = true;
            gameObject.GetComponent<TutorialText>().TutorialTextFunction(String.Empty);
        }

        if (Input.GetKeyDown(KeyCode.Return) && PlayerWasInCave)
        {
            ObjectiveImage.SetActive(false);
            playerMovement.enabled = true;
             gameObject.GetComponent<TutorialText>().TutorialTextFunction(String.Empty);
        }

    }


    void ChangeText()
    {
       
            if (Input.GetKeyDown(KeyCode.Return))
            {
            NumberOfTimesEnterWasPressed++;
            if (NumberOfTimesEnterWasPressed == 1)
            {
                Objective1.text = Text2;


            }
           
            else if(NumberOfTimesEnterWasPressed == 2)
            {
                ObjectiveImage.SetActive(false);
                gameObject.GetComponent<TutorialText>().TutorialTextFunction(String.Empty);
            }
           
        }
        
    }

    void AreEnemiesDead()
    {

        if (Deads.Length == EnemyCount && !EnemiesAreDead)
        {
            ObjectiveImage.SetActive(true);
            Objective1.text = Text3;
            EnemiesAreDead = true;

        }
        if (EnemiesAreDead)
        {

            if (Input.GetKeyDown(KeyCode.Return))
            {
                ObjectiveImage.SetActive(false);
                ObjectiveImage.GetComponentInChildren<Text>().text = String.Empty;
                 gameObject.GetComponent<TutorialText>().TutorialTextFunction(String.Empty);
            }

        }
         MissionComplete();
         MissionComplete2();
    }

    void MissionComplete()
    {
        if (EnemiesAreDead)
        {
            if (InventoryList.Contains(Gold) && !isMissionCompleted)
            {
               
                ObjectiveImage.SetActive(true);
                MissionCompleteText.SetActive(true);
                isMissionCompleted = true;
                ObjectiveImage.GetComponentInChildren<Text>().text = "Now go to the volcano island and find the entrance to to cave on the southwestern side";
                MissionCompleteSound.Play();
                
            }

        
            
        }


    }

   

    void MissionComplete2()
    {
        
            if (InventoryList.Contains(Ring) && !isMissionCompleted2)
            {
                MissionCompleteText.SetActive(true);
                ObjectiveImage.SetActive(true);
                isMissionCompleted2 = true;
                ObjectiveImage.GetComponentInChildren<Text>().text = "Now you should visit the shopman on the another island!";
                MissionCompleteSound.Play();
            }
            
        

        if (Input.GetKeyDown(KeyCode.Return) && isMissionCompleted2)
        {
            ObjectiveImage.SetActive(false);
            gameObject.GetComponent<TutorialText>().TutorialTextFunction(String.Empty);
        }

        }

    public void Vulcano(){
        if(!VolcanoMissionStarted){
         ObjectiveImage.SetActive(true);
         MissionCompleteText.SetActive(false);
         ObjectiveImage.GetComponentInChildren<Text>().text = "Welcome to the volcano! \n Find the entrance of the cave! It is located on the southwestern part of the island";
         ObjectiveImage.GetComponentInChildren<Text>().fontSize = 49;
         VolcanoMissionStarted = true;
         playerMovement.enabled = false;
         boatMovement.enabled = false;
         cameraController.enabled = false;
         gameObject.GetComponent<TutorialText>().TutorialTextFunction("Press Enter to continue");
         
        }

    }

    public void CaveEntrance(){

         if(!PlayerWasInCave){
         ObjectiveImage.SetActive(true);
         MissionCompleteText.SetActive(false);
         ObjectiveImage.GetComponentInChildren<Text>().text = "Go and find out, what is inside the cave!";
         PlayerWasInCave = true;
         playerMovement.enabled = false;
         boatMovement.enabled = false;
         cameraController.enabled = false;
         gameObject.GetComponent<TutorialText>().TutorialTextFunction("Press Enter to continue");
         PlayerAnimator.SetBool("isIdle", true);
         PlayerAnimator.SetBool("isRunning", false);
         PlayerAnimator.SetBool("isFastRunning", false);
         PlayerAnimator.SetBool("isJumping", false);

        }
    }
   
}