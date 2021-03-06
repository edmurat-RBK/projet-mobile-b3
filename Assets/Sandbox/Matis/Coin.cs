using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerManager.PMInstance.coinCounter += coinValue;
            Destroy(gameObject);
        }
    }
}
