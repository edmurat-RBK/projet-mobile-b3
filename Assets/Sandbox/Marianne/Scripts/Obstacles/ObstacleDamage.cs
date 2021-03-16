using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDamage: MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log($"Obstacle Collide with {other.gameObject.name}");
            GameManager.Instance.playerManager.playerLife -= 1;
        }
    }
}
