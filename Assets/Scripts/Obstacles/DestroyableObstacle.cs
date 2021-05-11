using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObstacle : MonoBehaviour
{
    public GameObject FxDestructionObstacles;
    public GameObject FxSmokeObstacle;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioManager.AMInstance.rockDestructionAudio.Post(gameObject);
            Destroy(gameObject);
            GameObject fx = Instantiate(FxDestructionObstacles, transform.position, transform.rotation);
            GameObject fxdeux = Instantiate(FxSmokeObstacle, transform.position, transform.rotation);

            
        }
    }
}

