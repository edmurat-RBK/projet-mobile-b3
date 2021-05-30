using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //public int coinValue = 1;
    public bool coinNeedToMove;

    GameManager gameManager;

    private void Start()
    {
       gameManager = GameManager.Instance;
    }

    private void Update()
    {
        if(coinNeedToMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.back * 100), 10 * Time.deltaTime);
        }

        if (transform.position.z < gameManager.ennemiManager.deadZone.position.z)
        {
            Destroy(gameObject);
        }
    }


    /*private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (gameManager.economicManager.multiplyCoins)
            {
                gameManager.economicManager.coinCounter += (int)(coinValue * gameManager.economicManager.coinsMultiplier);
            }
            else
            {
                gameManager.economicManager.coinCounter += coinValue;
            }

            AudioManager.AMInstance.coinCollectAudio.Post(gameObject);
            Destroy(gameObject);
        }
    }*/
}
