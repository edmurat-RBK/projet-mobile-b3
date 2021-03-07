using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDamage: MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerLife.playerLifeInstance.playerLife =- 1;
        }
    }
}
