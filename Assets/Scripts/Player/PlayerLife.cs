using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Matis Duperray | Player Life
/// Script who manage the player life and the decrease over time
/// </summary>



public class PlayerLife : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.playerManager.playerIsAlive = true;
    }

    void Update()
    {
        LifeDecreaseOverTime();


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
        GameManager.Instance.playerManager.playerIsAlive = false;
        Debug.Log("Player is Dead");
    }
    #endregion
}