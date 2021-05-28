using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMacro1 : MonoBehaviour
{
    public LoadMenu loadMenu;
    public DataManager dataManager;
    

    public bool multiplier;
    public int multiplierPrice = 5;
    
    public bool doubleCoins;
    public int doubleCoinsPrice = 5;
    
    public bool revive;
    public int extraLifePrice = 5;
    
    public int maxLife;
    public int maxLifePrice = 5;
    public int maxLifePriceIncrement = 5;
    public bool startShield;
    public int startShieldPrice = 5;
    public int startShieldPriceIncrement = 5;


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
    
    public void StartingShield()
    {
        if (loadMenu.purpleCoins > startShieldPrice && !startShield)
        {
            startShield = true;
            loadMenu.purpleCoins -= startShieldPrice;
            UpdatePrices();
            loadMenu.DisplayValues();
        }
    }

    public void Multiplier()
    {
        
        if (loadMenu.purpleCoins > multiplierPrice)
        {
            
            
            multiplier = true;
            loadMenu.purpleCoins -= multiplierPrice;
            
            UpdatePrices();
            loadMenu.DisplayValues();
        }

    }

    public void DoubleCoins()
    {
        if (loadMenu.purpleCoins > doubleCoinsPrice)
        {
            
            
            loadMenu.purpleCoins -= doubleCoinsPrice;
            
            doubleCoins = true;
            UpdatePrices();
            loadMenu.DisplayValues();
        }

    }

    public void ExtraLife()
    {
        if (loadMenu.purpleCoins > extraLifePrice && !revive)
        {
            
            revive = true;
            loadMenu.purpleCoins -= extraLifePrice;
            
            UpdatePrices();
            loadMenu.DisplayValues();
        }

    }

    public void MaxLife()
    {
        if (loadMenu.purpleCoins > maxLifePrice)
        {
            
            
            maxLife += 10;
            loadMenu.purpleCoins -= maxLifePrice;
            maxLifePrice += maxLifePriceIncrement;
            UpdatePrices();
            loadMenu.DisplayValues();
        }
        
    }
}
