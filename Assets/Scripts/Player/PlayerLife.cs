using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Matis Duperray | Player Life
/// Script who manage the player life and the decrease over time
/// </summary>



public class PlayerLife : MonoBehaviour
{
    #region Variables
    public bool playerIsAlive;



    public float maxPlayerLife = 10f;
    public float playerLife = 10f;

    public float lifeDecreaseSpeed = 1f;
    public float decreaseMultiplicator = 0f;
    #endregion


    void Start()
    {
        playerIsAlive = true;
    }

    void Update()
    {
        LifeDecreaseOverTime();


        if (playerLife <= 0 && playerIsAlive)
        {
            PlayerDeath();
        }
    }


    #region Fonctions
    void LifeDecreaseOverTime()
    {
        if(playerIsAlive)
        {
            playerLife -= (lifeDecreaseSpeed * decreaseMultiplicator * Time.deltaTime);
        }
    }

    void PlayerDeath()
    {
        playerIsAlive = false;
        Debug.Log("Player is Dead");
    }
    #endregion
}