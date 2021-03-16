using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDamage: MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.playerManager.playerLife -= 1;
        }
    }
}
