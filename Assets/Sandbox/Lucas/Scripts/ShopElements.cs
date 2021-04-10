using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopElements : MonoBehaviour
{
    
    
    public void RefillFuel()
    {
        GameManager.Instance.playerManager.playerLife = GameManager.Instance.playerManager.maxPlayerLife;
    }

    public void IncreaseMaxFuel()
    {
        GameManager.Instance.playerManager.maxPlayerLife += GameManager.Instance.playerManager.maxFuelIncrease;
    }

    public void ExtraLife()
    {
        GameManager.Instance.playerManager.revive = true;
    }

    public void Shield()
    {
        GameManager.Instance.playerManager.shield = GameManager.Instance.playerManager.maxShield;
    }

    public void RefillableShield()
    {
        GameManager.Instance.playerManager.refilableShield = true;
    }

    public void CoinsMultiplier()
    {
        GameManager.Instance.economicManager.multiplyCoins = true;
    }

    public void FuelMultiplier()
    {
        //augmenter le taux du ramassage d'essence
    }
}
