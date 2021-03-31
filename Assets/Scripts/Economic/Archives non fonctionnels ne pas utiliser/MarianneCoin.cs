using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarianneCoin : MonoBehaviour
{
     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            TotalPiece.tpinstance.totalPiece += 1;
            Destroy(gameObject);
            
        }
    }
}
