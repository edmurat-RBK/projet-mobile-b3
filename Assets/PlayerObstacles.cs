using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObstacles : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            if ((GameManager.Instance.playerManager.player.GetComponent<Boost>().isBoosting))
            {
                GameManager.Instance.playerManager.playerLife += 0;
            }

            else if (GameManager.Instance.playerManager.shield <= 0)
            {
                GameManager.Instance.playerManager.playerLife -= 1;


                int index = Random.Range(1, 11);
                if (index <= 4)
                {
                    AudioManager.AMInstance.playerDamageVoiceAudio.Post(gameObject);
                }
            }
            else
            {
                GameManager.Instance.playerManager.shield -= 1;
            }

        }
    }
}
