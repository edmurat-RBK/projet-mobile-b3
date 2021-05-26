using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDamage: MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if ((GameManager.Instance.playerManager.player.GetComponent<Boost>().isBoosting))
            {
                GameManager.Instance.playerManager.playerLife += 0;
            }
            else if (GameManager.Instance.playerManager.shield <= 0)
            {
                GameManager.Instance.playerManager.playerLife -= 1;
            }
            else
            {
                GameManager.Instance.playerManager.shield -= 1;
            }
            
        }
    }
}
