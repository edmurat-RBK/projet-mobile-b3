using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMacro1 : MonoBehaviour
{
    public LoadMenu loadMenu;
    public DataManager dataManager;
    

    public int multiplier;
    public int multiplierPrice = 5;
    public int multiplierPriceIncrement = 5;
    public int coinsMulti;
    public int doubleCoinsPrice = 5;
    public int doubleCoinsPriceIncrement = 5;
    public int extraLives;
    public int extraLifePrice = 5;
    public int extraLifePriceIncrement = 5;
    public int maxLife;
    public int maxLifePrice = 5;
    public int maxLifePriceIncrement = 5;


    public Text multiplierText;
    public Text doubleCoinsText;
    public Text extraLife;
    public Text maxLifeText;

    private void Start() {
        loadMenu = FindObjectOfType<LoadMenu>();
        dataManager = FindObjectOfType<DataManager>();
        
        UpdatePrices();
    }

    public void UpdatePrices()
    {
        multiplierText.text = multiplierPrice.ToString();
        doubleCoinsText.text = doubleCoinsPrice.ToString();
        extraLife.text = extraLifePrice.ToString();
        maxLifeText.text = maxLifePrice.ToString();
        
    }
    
    

    public void Multiplier()
    {
        
        if (loadMenu.purpleCoins > multiplierPrice)
        {
            
            
            multiplier += 1;
            loadMenu.purpleCoins -= multiplierPrice;
            multiplierPrice += multiplierPriceIncrement;
            UpdatePrices();
            loadMenu.DisplayValues();
        }

    }

    public void DoubleCoins()
    {
        if (loadMenu.purpleCoins > doubleCoinsPrice)
        {
            
            Debug.Log("hahah    ");
            loadMenu.purpleCoins -= doubleCoinsPrice;
            doubleCoinsPrice += doubleCoinsPriceIncrement;
            coinsMulti += 2;
            UpdatePrices();
            loadMenu.DisplayValues();
        }

    }

    public void ExtraLife()
    {
        if (loadMenu.purpleCoins > extraLifePrice)
        {
            
            Debug.Log("hahah    ");
            extraLives += 1;
            loadMenu.purpleCoins -= extraLifePrice;
            extraLifePrice += extraLifePriceIncrement;
            UpdatePrices();
            loadMenu.DisplayValues();
        }

    }

    public void MaxLife()
    {
        if (loadMenu.purpleCoins > maxLifePrice)
        {
            
            Debug.Log("hahah    ");
            maxLife += 10;
            loadMenu.purpleCoins -= maxLifePrice;
            maxLifePrice += maxLifePriceIncrement;
            UpdatePrices();
            loadMenu.DisplayValues();
        }
        
    }
}
