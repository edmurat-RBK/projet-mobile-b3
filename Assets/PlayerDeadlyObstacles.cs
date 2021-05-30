using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadlyObstacles : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DeadlyObstacle")
        {

            if (GameManager.Instance.playerManager.shield <= 0)
            {
                GameManager.Instance.playerManager.playerLife -= GameManager.Instance.playerManager.playerLife;
            }
            else
            {
                GameManager.Instance.playerManager.shield -= GameManager.Instance.playerManager.shield;
            }
        }
    }
    
}
