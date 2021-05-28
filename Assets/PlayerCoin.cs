using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoin : MonoBehaviour
{
    public int coinValue = 1;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Coin")
        {
            if (gameManager.economicManager.doubleCoins)
            {
                gameManager.economicManager.coinCounter += (int)(coinValue * gameManager.economicManager.coinsMultiplier);
            }
            else
            {
                gameManager.economicManager.coinCounter += coinValue;
            }

            AudioManager.AMInstance.coinCollectAudio.Post(gameObject);
            Destroy(other.gameObject);
        }
    }
}
