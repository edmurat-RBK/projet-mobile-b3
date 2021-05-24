using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomicManager : MonoBehaviour
{
    public bool multiplyCoins;
    public float boostDuration = 10f;
    public float coinsMultiplier = 2f;
    public int coinCounter = 0;
    public int coinVioletCounter = 0;

    private void Start() {
        LoadValues();
    }

    void LoadValues()
    {
        ShopData data = DataManager.DMInstance.LoadShop();
        
        
        if (data != null)
        {
            
            coinsMultiplier += data.coinsMulti;
            
            
        }
        
    }
}
