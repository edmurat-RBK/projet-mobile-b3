using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/// <summary>
/// Matis Duperray | Player Life
/// Script that manages the player life that decreases it over time
/// </summary>



public class PlayerLife : MonoBehaviour
{
    public GameObject explosionFX;
    void Start()
    {
        GameManager.Instance.playerManager.playerIsAlive = true;

    }

    void Update()
    {
        LifeDecreaseOverTime();

        RefillShield();
        if (GameManager.Instance.playerManager.refilableShield && GameManager.Instance.playerManager.shield == 0)
        {
            GameManager.Instance.playerManager.rechargeShield = true;
        }

        if (GameManager.Instance.playerManager.playerLife <= 0 && GameManager.Instance.playerManager.playerIsAlive)
        {
            PlayerDeath();
        }
    }


    #region Fonctions
    void LifeDecreaseOverTime()
    {
        if(GameManager.Instance.playerManager.playerIsAlive)
        {
            GameManager.Instance.playerManager.playerLife -= (GameManager.Instance.playerManager.lifeDecreaseSpeed * GameManager.Instance.playerManager.decreaseMultiplicator * Time.deltaTime);
        }
    }

    void PlayerDeath()
    {
        if (!GameManager.Instance.playerManager.revive)
        {
            explosionFX.SetActive(true);
            GameManager.Instance.playerManager.player.GetComponent<PlayerController>().animator.SetTrigger("isHurt");
            GameManager.Instance.playerManager.playerIsAlive = false;
            DataManager.DMInstance.Save(GameManager.Instance.highScoreManager.displayedScore,GameManager.Instance.economicManager.coinCounter);
            Debug.Log("Player is Dead");

        }
        else
        {
            GameManager.Instance.playerManager.revive = false;
        }
        
    }

    void RefillShield()
    {
        if(GameManager.Instance.playerManager.shield < GameManager.Instance.playerManager.maxShield && GameManager.Instance.playerManager.rechargeShield)
        {
            GameManager.Instance.playerManager.shield += (GameManager.Instance.playerManager.shieldRechargeRate * Time.deltaTime);
        }
        else if (GameManager.Instance.playerManager.shield == GameManager.Instance.playerManager.maxShield)
        {
            GameManager.Instance.playerManager.rechargeShield = false;
        }
    }
    #endregion
}