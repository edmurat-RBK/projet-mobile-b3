using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoin : MonoBehaviour
{
    public int coinValue = 1;
    GameManager gameManager;
    public GameObject coinFx;

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
                coinFx.SetActive(false);
                gameManager.economicManager.coinCounter += (int)(coinValue * gameManager.economicManager.coinsMultiplier);
                coinFx.SetActive(true);
            }
            else
            {
                coinFx.SetActive(false);
                gameManager.economicManager.coinCounter += coinValue;
                coinFx.SetActive(true);
            }

            AudioManager.AMInstance.coinCollectAudio.Post(gameObject);
            Destroy(other.gameObject);
        }
    }
}
