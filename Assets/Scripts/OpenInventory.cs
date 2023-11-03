using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public class OpenInventory : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject Inventory;
    [SerializeField] GameObject currentItem;
    [SerializeField] GameObject BuyButton;
    [SerializeField] GameObject SellButton;
    [SerializeField] GameObject HatItem;
    [SerializeField] GameObject BuyItemButton;
    [SerializeField] GameObject SellItemButton;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject PriceOfItem;

    GameObject[] SellableItems;
    GameObject[] UnsellableItems;
    GameObject[] ShopItems;

    public List<GameObject> InventoryList = new List<GameObject>(14);
    
    public static float ItemPositionX;

    Vector3 ItemPosition = new Vector3(0, 0, 0);

    [SerializeField] Text InventoryTitle;

    [SerializeField] PlayerMovement playerMovement;

    [SerializeField] CameraController cameraController;

    [SerializeField] BoatController boatController;

    void Start()
    {
        ItemPositionX = -300;
        
    }

    void Update()
    {
        UnsellableItems = GameObject.FindGameObjectsWithTag("Unsellable Item");
        SellableItems = GameObject.FindGameObjectsWithTag("Sellable Item");
        ShopItems = GameObject.FindGameObjectsWithTag("ShopItem");

        ItemPosition = new Vector3(ItemPositionX, 0, 0);
        if (!MainMenu.activeSelf)
        {
            if(!boatController.isMounted){
            if (Input.GetKeyDown(KeyCode.Q))
            {
               
                InventoryTitle.text = "Inventory";
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
                if (Inventory.activeSelf)
                {
                    Inventory.SetActive(false);
                    Player.GetComponent<Animator>().enabled = true;
                    Cursor.visible = false;
                    InventoryTitle.text = "Inventory";
                    BuyButton.SetActive(false);
                    SellButton.SetActive(false);
                    HatItem.SetActive(false);
                    BuyItemButton.SetActive(false);
                    if(!boatController.isMounted){
                    playerMovement.enabled = true;
                    }
                    cameraController.enabled = true;
                    PriceOfItem.SetActive(false);
                
                }
                else
                {
                    playerMovement.enabled = false;
                    Inventory.SetActive(true); 
                    Cursor.visible = true;
                    SellItemButton.SetActive(false);
                    cameraController.enabled = false;
                    Player.GetComponent<Animator>().enabled = false;
                  
                }

            }
            }
            if(Inventory.activeSelf && Input.GetKeyDown(KeyCode.Escape))
            {
                
                Inventory.SetActive(false);
                playerMovement.enabled = true;
                cameraController.enabled = true;
            }
        }
    }

    public void ItemGenerator()
    {
        
        
            for (int i = 0; i < InventoryList.Count; i++)
            {
                if(InventoryList[i].name!="DontDelete"){
                   
                currentItem = Inventory.transform.Find(InventoryList[i].name + " Item").gameObject;
                if(currentItem){
                currentItem.transform.localPosition = new Vector3(currentItem.transform.localPosition.x+100, 0, 0);;
                currentItem.transform.SetParent(Inventory.transform, false);
                currentItem.transform.localScale = new Vector3(1, 1, currentItem.transform.localScale.z);
                }
                }
            
           
            }
        
    }

    string FirstWord(string str){
        return Regex.Replace(str.Split()[0], @"[^0-9a-zA-Z\ ]+", "");
    }

    string RemoveLastWord(string str){

        string[] words = str.Split(new[] { " " }, StringSplitOptions.None);
        if(words.Length>1){
        string strTrimmed=str.Trim();
        return strTrimmed.Substring(strTrimmed.LastIndexOf(" ",strTrimmed.Length));
        }
        return str;
    }

}
