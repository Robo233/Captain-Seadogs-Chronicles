using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class ShowPrice : MonoBehaviour
{
    [SerializeField] GameObject ItemInfo;
    [SerializeField] GameObject BuyButton;
    [SerializeField] GameObject SellItemObject;
    [SerializeField] GameObject SellItemButton;
    [SerializeField] GameObject BuyItemButton;
    [SerializeField] GameObject Coin;
    [SerializeField] GameObject Hat;
    [SerializeField] GameObject HatItem;
    [SerializeField] GameObject ItemText;
    [SerializeField] GameObject DontDelete;

    [SerializeField] Text NameOfItem;
    [SerializeField] Text PriceOfItemText;
    [SerializeField] Text TotalMoneyText;

    string NameOfButton;

    [SerializeField] int Price;
    [SerializeField] int TotalMoney;

    OpenInventory openInventory;

    void Start()
    {
        TotalMoney = 0;
        openInventory = gameObject.GetComponent<OpenInventory>();
    }

  void ShowPriceFunction()
    {
        NameOfButton = EventSystem.current.currentSelectedGameObject.name;
        if ((GameObject.Find(NameOfButton)).tag == "Sellable Item")
        {
            if (BuyButton.activeSelf)
            {
          
                
                NameOfItem.text = FirstWord(NameOfButton) + ":";
                SellItemButton.SetActive(true);

                if (NameOfButton == "Gem Item")
                {
                    ActivatePrice(20,-4.5f,52.05f);
                }
                else if (NameOfButton == "Iron Item")
                {

                    ActivatePrice(10,-13.1f,53.8f);
                }
                 else if (NameOfButton == "Gold Treasure Collectible Item")
                {
                   
                    ActivatePrice(20,-13.1f,52.05f);
                }
                 else if (NameOfButton == "Ring Treasure Collectible Item")
                {
                    ActivatePrice(100,-29.9f,37.7f);
                }
                 else if (NameOfButton == "Emerald Treasure Collectible Item")
                {
        
             
                    ActivatePrice(20,-66.58f,52.05f);
                }

                
            }
        }
        else
        {
            SellItemObject.SetActive(false);
            Coin.SetActive(false);
            PriceOfItemText.text = "";
            
        }

    }

    void ShowPriceHat()
    {
        BuyItemButton.SetActive(true);
        ItemInfo.SetActive(true);
        ItemText.SetActive(true);
        SellItemObject.SetActive(true);
        NameOfItem.text = "Hat:";
        ActivatePrice(20,-9.23f,52.05f);
    }

    string FirstWord(string str)
    {
        string[] words = str.Split(new[] { " " }, StringSplitOptions.None);
	    return words[0];
    }

    void SellItem()
    {
       
            ItemInfo.SetActive(false);
            SellItemButton.SetActive(false);
            (GameObject.Find(NameOfButton)).SetActive(false);
            TotalMoney += Price;
            TotalMoneyText.text = TotalMoney.ToString();
            OpenInventory.ItemPositionX -= 100;
            List<GameObject> InventoryList = gameObject.GetComponent<OpenInventory>().InventoryList;
            GameObject objectToFind = GameObject.Find(RemoveLastSpecifiedWord(NameOfButton, " Item"));
            int index = InventoryList.IndexOf(objectToFind);
            gameObject.GetComponent<OpenInventory>().InventoryList[index] = DontDelete; // Ki kell cserelje, nem kitorolje
            
    }

  void BuyItem()
    {
        if (TotalMoney >= 20)
        {
            Hat.SetActive(true);
            TotalMoney -= 20;
            TotalMoneyText.text = TotalMoney.ToString();
        }
    }
    

   string RemoveLastSpecifiedWord(string str, string StringToRemove){
	if(str.Substring(str.Length - StringToRemove.Length)==StringToRemove){
	return str.Remove(str.Length-StringToRemove.Length);
	}
	return str;
    }

    void ActivatePrice(int price, float positionXItem, float positionXPrice){

        ItemInfo.SetActive(true);
        Price = price;
        NameOfItem.transform.localPosition = new Vector3(positionXItem,0,0);
        PriceOfItemText.transform.localPosition = new Vector3(positionXPrice,0,0);
        PriceOfItemText.text = Price.ToString();

    }
}