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
    public GameObject gameOver;

    [HideInInspector]
    public int enemiesDestroyed;
    [HideInInspector]
    public int objectsDestroyed;
    
    float scrollSpeed;
    
    private PlayerManager playerManager;
    private EnnemiManager ennemiManager;

    
    private void Awake() {
        playerManager = GameManager.Instance.playerManager;
        ennemiManager = GameManager.Instance.ennemiManager;
    }

    void Start()
    {
        scrollSpeed = GameManager.Instance.terrainManager.scrollSpeed;
        playerManager.playerIsAlive = true;
        playerManager.playerLife = playerManager.maxPlayerLife;
        if (playerManager.shieldActive)
        {
           playerManager.shield = playerManager.maxShield; 
        }
        
    }

    void Update()
    {
        
        LifeDecreaseOverTime();

        // RefillShield();
        // if (playerManager.refilableShield && playerManager.shield == 0)
        // {
        //     playerManager.rechargeShield = true;
        // }

        if (playerManager.playerLife <= 0 && playerManager.playerIsAlive)
        {
            StartCoroutine(PlayerDeath());
        }
    }




    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == ("Mine"))
        {
            if (playerManager.shieldActive && ennemiManager.mineDamage<playerManager.shield)
            {
                playerManager.shield -= ennemiManager.mineDamage;
            }
            else if (ennemiManager.mineDamage>playerManager.shield && playerManager.shieldActive)
            {
                playerManager.playerLife -= (ennemiManager.mineDamage - playerManager.shield);
                playerManager.shield = 0;
            }
            else
            {
                playerManager.playerLife -= ennemiManager.mineDamage;
            }

            
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

    public IEnumerator PlayerDeath()
    {
        
        if (!playerManager.revive)
        {
            
            explosionFX.SetActive(true);
            playerManager.player.GetComponent<PlayerController>().animator.SetTrigger("isHurt");
            AudioManager.AMInstance.explosionAudio.Post(gameObject);
            playerManager.playerIsAlive = false;
            playerManager.revive = false;
            //DataManager.DMInstance.Save(GameManager.Instance.highScoreManager.displayedScore,GameManager.Instance.economicManager.coinCounter);
            GameManager.Instance.terrainManager.scrollSpeed = 0;
            
            
            
            yield return new WaitForSeconds(2f);
            gameOver.SetActive(true);
            gameOver.GetComponent<Gameover>().CalculateScore(enemiesDestroyed,objectsDestroyed,GameManager.Instance.economicManager.coinCounter,FindObjectOfType<UIDisplay>().displayedScore);
            DataManager.DMInstance.Save(FindObjectOfType<UIDisplay>().displayedScore,GameManager.Instance.economicManager.coinCounter,GameManager.Instance.economicManager.coinVioletCounter);
        }
        else if (playerManager.revive)
        {
            GameManager.Instance.terrainManager.scrollSpeed = scrollSpeed;
            Debug.Log("hummmm0");
            playerManager.playerIsAlive = true;
            playerManager.playerLife = playerManager.maxPlayerLife;
            yield return 0;
            
            
            
        }
        

        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu Start");
    }

    // void RefillShield()
    // {
    //     if(playerManager.shield < playerManager.maxShield && playerManager.rechargeShield)
    //     {
    //         playerManager.shield += (playerManager.shieldRechargeRate * Time.deltaTime);
    //     }
    //     else if (playerManager.shield == playerManager.maxShield)
    //     {
    //         playerManager.rechargeShield = false;
    //     }
    // }
    #endregion
}