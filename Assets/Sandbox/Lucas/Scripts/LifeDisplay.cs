using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDisplay : MonoBehaviour
{
    public Text playerLife;
    int playerHp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerHp = (int)GameManager.Instance.playerManager.playerLife;
        playerLife.text = playerHp.ToString();
    }
}
