using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SHopMacro : MonoBehaviour
{
    public ShopManager shopManager;
    public EconomicManager economicManager;
    public PlayerManager playerManager;

    public int multiplierPrice = 5;
    public int multiplierPriceIncrement = 5;
    public int doubleCoinsPrice = 5;
    public int doubleCoinsPriceIncrement = 5;
    public int extraLifePrice = 5;
    public int extraLifePriceIncrement = 5;
    public int maxLifePrice = 5;
    public int maxLifePriceIncrement = 5;


    public Text multiplierText;
    public Text doubleCoinsText;
    public Text extraLife;
    public Text maxLifeText;

    private void Start() {
        shopManager = GameManager.Instance.shopManager;
        economicManager = GameManager.Instance.economicManager;
        playerManager = GameManager.Instance.playerManager;
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
        if (economicManager.coinVioletCounter > multiplierPrice)
        {
            GameManager.Instance.highScoreManager.multiplier += 1;
            economicManager.coinVioletCounter -= multiplierPrice;
            multiplierPrice += multiplierPriceIncrement;
            
        }

    }

    public void DoubleCoins()
    {
        if (economicManager.coinVioletCounter > doubleCoinsPrice)
        {
            doubleCoinsPrice += doubleCoinsPriceIncrement;
            economicManager.coinVioletCounter -= doubleCoinsPrice;
            GameManager.Instance.economicManager.coinsMultiplier = 2;
        }

    }

    public void ExtraLife()
    {
        if (economicManager.coinVioletCounter > extraLifePrice)
        {
            if (GameManager.Instance.playerManager.revive)
            {
                GameManager.Instance.playerManager.numberOfRevives += 1;
            }
            else
            {
                GameManager.Instance.playerManager.revive = true;
                GameManager.Instance.playerManager.numberOfRevives += 1;
            }
            economicManager.coinVioletCounter -= extraLifePrice;
            extraLifePrice += extraLifePriceIncrement;
        }

    }

    public void MaxLife()
    {
        if (economicManager.coinVioletCounter > maxLifePrice)
        {
            GameManager.Instance.playerManager.maxPlayerLife += GameManager.Instance.playerManager.maxFuelIncrease;
            economicManager.coinVioletCounter -= maxLifePrice;
            maxLifePrice += maxLifePriceIncrement;
        }
        
    }
}
