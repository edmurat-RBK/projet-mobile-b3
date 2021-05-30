using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public void UpgradeLife(int price)
    {

        if (GameManager.Instance.economicManager.coinCounter >= price)
        {
            GameManager.Instance.playerManager.lifeUpgrade++;
            GameManager.Instance.economicManager.coinCounter -= price;
        }
            
    }

    public void UpgradeBoostCooldown(int price)
    {
        if (GameManager.Instance.economicManager.coinCounter >= price)
        {
            GameManager.Instance.playerManager.boostCoolDownUpgrade++;
            GameManager.Instance.economicManager.coinCounter -= price;
        }
            
    }

    public void UpgradeBoostDamage(int price)
    {
        if(GameManager.Instance.economicManager.coinCounter >= price)
        {
            GameManager.Instance.playerManager.boostDamages++;
            GameManager.Instance.economicManager.coinCounter -= price;
        }
    }

    public void CloseShop() { 
        GameManager.Instance.shopManager.shopActive = false;
        GameManager.Instance.shopManager.shopUI.SetActive(false);
    }
}
