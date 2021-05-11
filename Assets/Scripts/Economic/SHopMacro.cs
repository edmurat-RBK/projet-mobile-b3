using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHopMacro : MonoBehaviour
{
    





    public void Multiplier()
    {
        GameManager.Instance.highScoreManager.multiplier += 1;
    }

    public void DoubleCoins()
    {
        GameManager.Instance.economicManager.coinsMultiplier = 2;
    } 

    public void ExtraLife()
    {
          
    }
}
