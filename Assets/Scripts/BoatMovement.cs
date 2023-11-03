using System.Collections.Generic;
using UnityEngine;
using System;

public class BoatMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float groundCheckDistance;

    [SerializeField] private bool isGrounded;
    
    [SerializeField] private LayerMask groundMask;

    Vector3 moveDirection;
    Vector3 velocity;

    [SerializeField] float jumpSpeed;
    [SerializeField] float rotateSpeed = 3.0f;
    float ySpeed;
    float magnitude;
    float horizontalInput;
    float verticalInput;
    float EnemyPositionX;
    float PlayerPositionX;
    float EnemyPositionZ;
    float PlayerPositionZ;
    float PlayerEdgePositionX;
    float PlayerEdgePositionZ;
 

    [SerializeField] string MountBoatText;
    [SerializeField] string CollectTreasureText;
    [SerializeField] string SkipTutorialText;
    [SerializeField] string OpenChestText;

    [SerializeField] GameObject Player;
    [SerializeField] GameObject Edge;
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject Chest;
    [SerializeField] GameObject OpenedChest;
    [SerializeField] GameObject ChestCap;
    [SerializeField] GameObject ObjectiveImage3;
    [SerializeField] GameObject SceneLoader;
    [SerializeField] GameObject Treasure;
    [SerializeField] GameObject Gem;
    [SerializeField] GameObject Iron;
    [SerializeField] GameObject MissionCompleteScreen;
    [SerializeField] GameObject ClosestInteractable;

    [SerializeField] List<GameObject> Interactables = new List<GameObject>();

    [SerializeField] bool isGemCollected;
    [SerializeField] bool isIronCollected;
    [SerializeField] bool isPositionGoodForBoat;
    [SerializeField] bool isPositionGoodForShop;
    bool isDead;
    bool isTreasureFound;
    bool isChestOpened;
    bool start = false;

  

    Animator animator;
    Animator anim;

    CharacterController controller;

    [SerializeField] string[] Tags;

    Vector3 position;
    Vector3 movementDirection;
    Vector3 CameraLookBackPosition = new Vector3(0f,3.04f,2.83f);
    Vector3 OriginalCameraPosition;

    Quaternion CameraLookBackRotation =  Quaternion.Euler(25f,180f,0f);
    Quaternion OriginalCameraRotation;

    void Start()
    {
        controller = GetComponent < CharacterController > ();
        position = transform.position;

    }

    void Update()
    {

        transform.position = new Vector3(transform.position.x,0f,transform.position.z);
        Move();
        
        if (Input.GetKey(KeyCode.Mouse0) && !start)
        {
            start = true;
        }

    }


    void Move()
    {

        

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");
        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);

        if(moveZ>=0){
            SceneLoader.GetComponent<TutorialText>().TutorialTextFunction("Hold Shift to go faster");
        }

        if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)) 
            {

                Walk();
             
            
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift) )
            {
                if(moveZ > 0){
                
                Run();
                 
            
                }

            }


           
            moveDirection *= moveSpeed;
         
        Rotate();
    
    

        controller.Move(moveDirection * Time.deltaTime);

        controller.Move(velocity * Time.deltaTime);
    }

 

    void Walk()
    {
        moveSpeed = walkSpeed;
         
       

    }

    void Run()
    {
        moveSpeed = runSpeed;
        SceneLoader.GetComponent<TutorialText>().TutorialTextFunction(String.Empty);
    }



    void Rotate()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
    }


}

