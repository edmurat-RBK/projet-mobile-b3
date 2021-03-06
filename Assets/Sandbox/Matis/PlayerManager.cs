using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager PMInstance;



    public int coinCounter = 0;

    private void Awake()
    {
        if(PMInstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            PMInstance = this;
        }
    }
}
