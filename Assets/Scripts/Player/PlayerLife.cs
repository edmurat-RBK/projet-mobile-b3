using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



/// <summary>
/// Matis Duperray | Player Life
/// Script that manages the player life that decreases it over time
/// </summary>



public class PlayerLife : MonoBehaviour
{
    public GameObject explosionFX;

    private PlayerManager playerManager;
    private EnnemiManager ennemiManager;

    private void Awake() {
        playerManager = GameManager.Instance.playerManager;
        ennemiManager = GameManager.Instance.ennemiManager;
    }

    void Start()
    {
        playerManager.playerIsAlive = true;
    }

    void Update()
    {
        LifeDecreaseOverTime();

        RefillShield();
        if (playerManager.refilableShield && playerManager.shield == 0)
        {
            playerManager.rechargeShield = true;
        }

        if (playerManager.playerLife <= 0 && playerManager.playerIsAlive)
        {
            StartCoroutine(PlayerDeath());
        }
    }




    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == ("Mine"))
        {
            playerManager.playerLife -= ennemiManager.mineDamage;
        }

    }


    #region Fonctions
    void LifeDecreaseOverTime()
    {
        if(playerManager.playerIsAlive)
        {
            playerManager.playerLife -= (playerManager.lifeDecreaseSpeed * playerManager.decreaseMultiplicator * Time.deltaTime);
        }
    }

    IEnumerator PlayerDeath()
    {

        if (!playerManager.revive)
        {
            explosionFX.SetActive(true);
            playerManager.player.GetComponent<PlayerController>().animator.SetTrigger("isHurt");
            playerManager.playerIsAlive = false;
            //DataManager.DMInstance.Save(GameManager.Instance.highScoreManager.displayedScore,GameManager.Instance.economicManager.coinCounter);
            GameManager.Instance.terrainManager.scrollSpeed = 0;

            yield return new WaitForSeconds(2f);

            SceneManager.LoadScene("Menu Start");
        }
        else
        {
            yield return 0;
            playerManager.revive = false;
        }

        
    }

    void RefillShield()
    {
        if(playerManager.shield < playerManager.maxShield && playerManager.rechargeShield)
        {
            playerManager.shield += (playerManager.shieldRechargeRate * Time.deltaTime);
        }
        else if (playerManager.shield == playerManager.maxShield)
        {
            playerManager.rechargeShield = false;
        }
    }
    #endregion
}