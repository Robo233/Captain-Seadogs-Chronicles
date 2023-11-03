using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text.RegularExpressions;

public class PlayerMovement : MonoBehaviour
{
    float moveSpeed;
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float jumpHeight;
    [SerializeField] float groundCheckDistance;
    [SerializeField] float gravity;

    [SerializeField] bool isGrounded;
    
    [SerializeField] LayerMask groundMask;

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
    
    GameObject s;

    [SerializeField] GameObject ClosestInteractable;

    public List<GameObject> Interactables = new List<GameObject>();

    public bool isGemCollected;
    public bool isMounted;
    bool isDead;
    bool isChestOpened;

  

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
   
      for(int i=0;i<Tags.Length;i++){
            Interactables.AddRange (new List<GameObject> (GameObject.FindGameObjectsWithTag (Tags[i])));
      }
        position = transform.position;
        isGemCollected = false;


        animator = Player.GetComponent<Animator>();

    }

    void Update()
    {

        GameObject SceneLoader = GameObject.Find("SceneLoader");
        if(SceneLoader){
        EnemyController EnemyController = SceneLoader.GetComponent<EnemyController>();
        }
     

        
        EnemyDeath EnemyDeath = Enemy.GetComponent<EnemyDeath>();
        isDead = EnemyDeath.isDead;

        EnemyPositionX = Enemy.transform.position.x;
        PlayerPositionX = Player.transform.position.x;
        EnemyPositionZ = Enemy.transform.position.z;
        PlayerPositionZ = Player.transform.position.z;

        PlayerEdgePositionX = Edge.transform.position.x;
        PlayerEdgePositionZ = Edge.transform.position.z;

        Move();
        
        if (Input.GetMouseButtonDown(0) )
        {
           
            
            Attack(); 
            
        }

    ShowText();

  

    }

    void ShowText(){

        if(GetClosestInteractable(Interactables).Item2<10){

            if(GetClosestInteractable(Interactables).Item1.tag=="Collectible"){
              Collect();
        }

        else if(GetClosestInteractable(Interactables).Item1.tag=="chest"){
            if(GetClosestInteractable(Interactables).Item1.transform.Find("Chest_Closed").gameObject.activeSelf) {
              OpenChestFunction();
        }
        }

        else if(GetClosestInteractable(Interactables).Item1.tag=="Boat"){
        GetClosestInteractable(Interactables).Item1.GetComponent<BoatController>().Board();
        SceneLoader.GetComponent<TutorialText>().TutorialTextFunction("Press E to mount boat");
        }

        }
        else{
            string TutorialText;
            TutorialText = SceneLoader.GetComponent<TutorialText>().Tutorial.text;
            for(int i=0;i<Interactables.Count;i++){
                if(Interactables[i]){
            if(LastWord(TutorialText)==Interactables[i].name   || LastWord(TutorialText)=="chest" || LastWord(TutorialText)=="boat" || LastWord(TutorialText)=="Emerald" || LastWord(TutorialText)=="Ring" )
            {
            SceneLoader.GetComponent<TutorialText>().TutorialTextFunction(String.Empty);

            }
                }
            }
          
        }
            
        

    }

    (GameObject, float) GetClosestInteractable(List<GameObject> objects) 
    {
        GameObject tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = Player.transform.position;
        foreach (GameObject t in objects)
        {
            if(t){
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
            }
        }
       
        return (tMin,minDist);
    }

    void Collect(){
        SceneLoader.GetComponent<TutorialText>().TutorialTextFunction("Press E to collect " + FirstWord(GetClosestInteractable(Interactables).Item1.name));

            if (Input.GetKeyDown(KeyCode.E))
                {
                    for(int i=0;i<SceneLoader.GetComponent<OpenInventory>().InventoryList.Count;i++){
                        if(SceneLoader.GetComponent<OpenInventory>().InventoryList[i].name=="DontDelete"){
                            SceneLoader.GetComponent<OpenInventory>().InventoryList[i] = GetClosestInteractable(Interactables).Item1;
                            break;
                        }
                        }

                    SceneLoader.GetComponent<OpenInventory>().ItemGenerator();
                    GetClosestInteractable(Interactables).Item1.transform.position = new Vector3(GetClosestInteractable(Interactables).Item1.transform.position.x, -1000f, GetClosestInteractable(Interactables).Item1.transform.position.z);
                    SceneLoader.GetComponent<TutorialText>().TutorialTextFunction(String.Empty);
                    
                } 
    }

   void OpenChestFunction(){
       SceneLoader.GetComponent<TutorialText>().TutorialTextFunction("Press R to open chest");
              
            if (Input.GetKeyDown(KeyCode.R))
                {
                    GetClosestInteractable(Interactables).Item1.transform.Find("Chest_Closed").gameObject.SetActive(false);
                    GetClosestInteractable(Interactables).Item1.transform.Find("Chest_Open").gameObject.SetActive(true);
                    GetClosestInteractable(Interactables).Item1.transform.Find("Chest_Open_Cap").gameObject.SetActive(true); 
                    Transform Treasure = GetClosestInteractable(Interactables).Item1.transform.Find(GetClosestInteractable(Interactables).Item1.name + " Collectible");      
                    Treasure.gameObject.SetActive(true);
                    Interactables.Add(Treasure.gameObject);
                  
                }
   }

    void Move()
    {

        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");
        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);


        if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)) 
            {
                animator.SetBool("isFastRunning", false);
            if (moveZ > 0)
            {
                
                animator.SetBool("isRunningBackward", false);
                animator.SetBool("isRunning", true);

                 animator.SetBool("isIdle", false);
            }
            else
            {
                
                animator.SetBool("isRunningBackward", true);
                animator.SetBool("isRunning", false);
                
            }
                Walk();
            
            
        }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift) )
            {
                if(moveZ > 0){
                    animator.SetBool("isFastRunning", true);
                Run();
                
                animator.SetBool("isRunning", false);
                }
                else if(moveZ < 0){
                         Walk();
                animator.SetBool("isFastRunning", false);
                animator.SetBool("isRunningBackward", true);
                }
            }


            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }
            moveDirection *= moveSpeed;


           if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
            
                Jump();
         
            
            }

        if(!isMounted){
        Rotate();
        }
        if(controller.enabled){
        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        }
    }

    void Idle()
    {
       
        animator.SetBool("isRunning", false);
        animator.SetBool("isRunningBackward", false);
        animator.SetBool("isFastRunning", false);
        animator.SetBool("isJumping", false);
        animator.SetBool("isAttacking", false);

        animator.SetBool("isIdle", true);
    }

    void Walk()
    {
        moveSpeed = walkSpeed;
        animator.SetBool("isAttacking", false);

    }

    void Run()
    {
        moveSpeed = runSpeed;
        animator.SetBool("isAttacking", false);
    }



    void Jump()
    {
        
      velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        animator.SetBool("isJumping", true);
        animator.SetBool("isAttacking", false);

    }

    void Rotate()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
    }

    void OpenChest()
    {
        Chest.SetActive(false);
        OpenedChest.SetActive(true);
        ChestCap.SetActive(true);
        
       
    }

 


    void Attack()
    {
        
        animator.SetBool("isAttacking", true);
    
        EnemyDeath EnemyDeath = Enemy.GetComponent<EnemyDeath>();


        float dot = Vector3.Dot(Player.transform.forward, (Enemy.transform.position - Player.transform.position).normalized);
       
        
        if (Math.Abs(Math.Abs(EnemyPositionX) - Math.Abs(PlayerEdgePositionX)) < 2 && Math.Abs(Math.Abs(EnemyPositionZ) - Math.Abs(PlayerEdgePositionZ)) < 2 && EnemyDeath.isDead == false)

        {

                EnemyDeath.EnemyHealth--;
        
        }
    }


    string LastWord(string str){
        return str.Split(' ').Last();
    }

   string FirstWord(string str){
        return Regex.Replace(str.Split()[0], @"[^0-9a-zA-Z\ ]+", "");
    }

}

