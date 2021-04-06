using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    public bool coinNeedToMove;



    private void Update()
    {
        if(coinNeedToMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.back * 100), GameManager.Instance.terrainManager.scrollSpeed * Time.deltaTime);
        }

        if (transform.position.z < GameManager.Instance.ennemiManager.deadZone.position.z)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.Instance.economicManager.coinCounter += coinValue;
            Destroy(gameObject);
        }
    }
}
