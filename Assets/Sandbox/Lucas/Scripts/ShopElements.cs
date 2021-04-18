using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopElements : MonoBehaviour
{
    ShopManager shopManager;
    EconomicManager economicManager;
    PlayerManager playerManager;

    public Text refillFuel;
    public Text increaseMaxFuel;
    public Text extraLife;
    public Text refillShield;
    public Text refillableShield;
    public Text coinsMultiplier;

    private void Start() {
        shopManager = GameManager.Instance.shopManager;
        economicManager = GameManager.Instance.economicManager;
        playerManager = GameManager.Instance.playerManager;
    }
    private void Update() 
    {
        if (shopManager.shopActive)
        {
            UpdatePrices();
        }
    }
    public void UpdatePrices() 
    {
        refillFuel.text = shopManager.refillPrice.ToString();
        increaseMaxFuel.text = shopManager.increaseFuelPrice.ToString();
        extraLife.text = shopManager.extraLifePrice.ToString();
        refillShield.text = shopManager.refillShieldPrice.ToString();
        refillableShield.text = shopManager.refillableShieldPrice.ToString();
        coinsMultiplier.text = shopManager.CoinsMultiplierPrice.ToString();
    }
    public void CloseShop()
    {
        shopManager.shopActive = false;
        shopManager.shopUI.SetActive(false);
    }

    public void RefillFuel()
    {
        if (economicManager.coinCounter >= shopManager.refillPrice && playerManager.playerLife < playerManager.maxPlayerLife)
        {
           playerManager.playerLife = playerManager.maxPlayerLife;
            refillFuel.text = shopManager.refillPrice.ToString();
            economicManager.coinCounter -= shopManager.refillPrice;
            shopManager.refillPrice *= 2;
        }
        else
        {
            Debug.LogWarning("not enough Money or already full HP");
        }
        
    }

    public void IncreaseMaxFuel()
    {
        if (economicManager.coinCounter >= shopManager.increaseFuelPrice)
        {
            playerManager.maxPlayerLife +=playerManager.maxFuelIncrease;
            increaseMaxFuel.text = shopManager.increaseFuelPrice.ToString();
            economicManager.coinCounter -= shopManager.increaseFuelPrice;
            shopManager.increaseFuelPrice *= 2;
        }
        else
        {
            Debug.LogWarning("not enough Money");
        }
        
    }

    public void ExtraLife()
    {
        if (economicManager.coinCounter >= shopManager.extraLifePrice && !playerManager.revive)
        {
           playerManager.revive = true;
            extraLife.text = shopManager.extraLifePrice.ToString();
            economicManager.coinCounter -= shopManager.extraLifePrice;
            shopManager.extraLifePrice *= 2;
        }
        else
        {
            Debug.LogWarning("not enough Money or already purchased");
        }
        
    }

    public void Shield()
    {
        if (economicManager.coinCounter >= shopManager.refillShieldPrice && playerManager.shield < playerManager.maxShield)
        {
           playerManager.shield =playerManager.maxShield;
            refillShield.text = shopManager.refillShieldPrice.ToString();
            economicManager.coinCounter -= shopManager.refillShieldPrice;
            shopManager.refillShieldPrice *= 2;
        }
        else
        {
            Debug.LogWarning("not enough Money or already max shield");
        }
        
    }

    public void RefillableShield()
    {
        if (economicManager.coinCounter >= shopManager.refillableShieldPrice && !playerManager.refilableShield)
        {
            playerManager.refilableShield = true;
            refillableShield.text = shopManager.refillableShieldPrice.ToString();
            economicManager.coinCounter -= shopManager.refillableShieldPrice;
            shopManager.refillableShieldPrice *= 2;
        }
        else
        {
            Debug.LogWarning("not enough Money or already purchased");
        }
        
    }

    public void CoinsMultiplier()
    {
        if (economicManager.coinCounter >= shopManager.CoinsMultiplierPrice && !economicManager.multiplyCoins)
        {
            economicManager.multiplyCoins = true;
            coinsMultiplier.text = shopManager.CoinsMultiplierPrice.ToString();
            economicManager.coinCounter -= shopManager.CoinsMultiplierPrice;
            shopManager.CoinsMultiplierPrice *= 2;
            StartCoroutine(ResetMultiplier());
        }
        else
        {
            Debug.LogWarning("not enough Money or already purchased");
        }
    }

    public void FuelMultiplier()
    {
        //augmenter le taux du ramassage d'essence
    }

    IEnumerator ResetMultiplier()
    {
        yield return new WaitForSeconds(economicManager.boostDuration);
        economicManager.multiplyCoins = false;
    }
}
