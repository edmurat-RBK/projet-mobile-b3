using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObstacle : MonoBehaviour
{
    public GameObject FxDestructionObstacles;
    public GameObject FxSmokeObstacle;
    PlayerLife player;

    private void Start() {
        player = FindObjectOfType<PlayerLife>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioManager.AMInstance.rockDestructionAudio.Post(gameObject);
            if (player.gameObject.GetComponent<Boost>().isBoosting)
            {
                player.objectsDestroyed += 1;
            }
            
            Destroy(gameObject);
            GameObject fx = Instantiate(FxDestructionObstacles, transform.position, transform.rotation);
            GameObject fxdeux = Instantiate(FxSmokeObstacle, transform.position, transform.rotation);

            
        }
    }
}

