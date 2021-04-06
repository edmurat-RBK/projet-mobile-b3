using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinViolet : MonoBehaviour
{
    public int coinVioletValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.economicManager.coinVioletCounter += coinVioletValue;
            Destroy(gameObject);
        }
    }
}
