using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fire")
        {
            if (GameManager.Instance.playerManager.shield <= 0)
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
