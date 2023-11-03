using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class Shop : MonoBehaviour
{

    [SerializeField] GameObject ShopMenuScreen;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject ShopMan;
    [SerializeField] GameObject PressEToShop;
    [SerializeField] GameObject SellButton;
    [SerializeField] GameObject HatItem;
    [SerializeField] GameObject BuyItemButton;
    [SerializeField] GameObject SellItemButton;
    [SerializeField] GameObject ItemText;
    [SerializeField] GameObject PriceItemText;
    [SerializeField] GameObject CoinItemText;
    [SerializeField] GameObject BuyButton;
    [SerializeField] GameObject PriceOfItem;

    GameObject[] Frames;
    GameObject[] SellableItems;
    GameObject[] UnsellableItems;
    GameObject[] ShopItems;
   
    [SerializeField] List<GameObject> Shops = new List<GameObject>();

    [SerializeField] Text SellButtonText;
    [SerializeField] Text BuyButtonText;
    [SerializeField] Text InventoryTitle;

    [SerializeField] Color BuyButtonTextColor;
    [SerializeField] Color ButtonColor;
    [SerializeField] Color OriginalButtonColor;

    float ShopPositionX;
    float ShopPositionZ;
    float PlayerPositionX;
    float PlayerPositionZ;

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Animator playerAnimator;

    [SerializeField] CameraController cameraController;

    void Start()
    {
        Shops.AddRange (new List<GameObject> (GameObject.FindGameObjectsWithTag("Shop")));
    }

    
    void Update()
    {
        Frames = GameObject.FindGameObjectsWithTag("Frame");
        UnsellableItems = GameObject.FindGameObjectsWithTag("Unsellable Item");
        SellableItems = GameObject.FindGameObjectsWithTag("Sellable Item");
        ShopItems = GameObject.FindGameObjectsWithTag("ShopItem");
        ShopPositionX = ShopMan.transform.position.x;
        ShopPositionZ = ShopMan.transform.position.z;
        PlayerPositionX =  Player.transform.position.x;
        PlayerPositionZ = Player.transform.position.z;
        ShopMenu();

        if(!ShopMenuScreen.activeSelf){
            playerAnimator.enabled = true;
        }

    }

   void ShopMenu()
    {
        
        if(GetClosestInteractable(Shops).Item2<10){
            
            if (!ShopMenuScreen.activeSelf)
            {
                gameObject.GetComponent<TutorialText>().TutorialTextFunction("Press E to buy or sell");
              

                if (Input.GetKeyDown(KeyCode.E))
                {
                    ShopMenuOn();
                     
                }
                
               
            }
            else
            {
                gameObject.GetComponent<TutorialText>().TutorialTextFunction(String.Empty);
                if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Escape) )
                {
                    ShopMenuOff();
                    
                }
               
            }
        }
        else{
            if( LastWord(gameObject.GetComponent<TutorialText>().Tutorial.text)=="sell"){
            gameObject.GetComponent<TutorialText>().TutorialTextFunction(String.Empty);
           }
        }
            

       
    }

    void ShopMenuOn()
    {
        
        ShopMenuScreen.SetActive(true);
        InventoryTitle.text = "Shop";
        BuyButton.SetActive(true);
        SellButton.SetActive(true);
        Cursor.visible = true;
        BuyItemButton.SetActive(false);
        SellButtonText.color = BuyButtonTextColor;
        BuyButtonText.color = Color.black;
        HatItem.SetActive(false);
        SellItemButton.SetActive(false);
        playerMovement.enabled = false;
        playerAnimator.enabled = false;
        cameraController.enabled = false;
      
        for (int i = 0; i < SellableItems.Length; i++)
        {
            SellableItems[i].GetComponent<Image>().enabled = true;
        }
        for (int i = 0; i < UnsellableItems.Length; i++)
        {
            UnsellableItems[i].GetComponent<Image>().enabled = true;
        }
        for (int i = 0; i < ShopItems.Length; i++)
        {
            ShopItems[i].SetActive(false);
        }
    }
    void ShopMenuOff()
    {
        PriceOfItem.SetActive(false);
        ShopMenuScreen.SetActive(false);
        InventoryTitle.text = "Inventory";
        BuyButton.SetActive(false);
        SellButton.SetActive(false);
        playerMovement.enabled = true;
        playerAnimator.enabled = true;
        cameraController.enabled = true;
      
        for (int i = 0; i < SellableItems.Length; i++)
        {
            SellableItems[i].GetComponent<Image>().enabled = true;
        }
        for (int i = 0; i < UnsellableItems.Length; i++)
        {
            UnsellableItems[i].GetComponent<Image>().enabled = true;
        }
        for (int i = 0; i < ShopItems.Length; i++)
        {
            ShopItems[i].SetActive(false);
        }
    }
  public void BuyMenuOn()
    {
       
        BuyButtonText.color = BuyButtonTextColor;
        SellButtonText.color = Color.black;
        BuyButton.GetComponent<Image>().color = ButtonColor;
        SellButton.GetComponent<Image>().color = OriginalButtonColor;
        SellItemButton.SetActive(false);
        HatItem.SetActive(true);
        BuyItemButton.SetActive(false);
        ItemText.SetActive(false);
        PriceItemText.SetActive(false);
       
        for (int i = 0; i < SellableItems.Length; i++)
        {
            SellableItems[i].GetComponent<Image>().enabled = false;
        }
        for (int i = 0; i < UnsellableItems.Length; i++)
        {
            UnsellableItems[i].GetComponent<Image>().enabled = false;
        }
        for (int i = 0; i < ShopItems.Length; i++)
        {

            ShopItems[i].SetActive(true);
            
        }
    }

    public void SellMenuOn()
    {
        PriceOfItem.SetActive(false);
        BuyItemButton.SetActive(false);
        SellButtonText.color = BuyButtonTextColor;
        BuyButtonText.color = Color.black;
        SellButton.GetComponent<Image>().color = ButtonColor;
        BuyButton.GetComponent<Image>().color = OriginalButtonColor;
        HatItem.SetActive(false);
        SellItemButton.SetActive(false);
      
        for (int i = 0; i < SellableItems.Length; i++)
        {
            SellableItems[i].GetComponent<Image>().enabled = true;
        }
        for (int i = 0; i < UnsellableItems.Length; i++)
        {
            UnsellableItems[i].GetComponent<Image>().enabled = true;
        }
        for (int i = 0; i < ShopItems.Length; i++)
        {
            ShopItems[i].SetActive(false);
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

      public string LastWord(string str){
        return str.Split(' ').Last();
    }
}