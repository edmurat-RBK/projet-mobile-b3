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
        playerHp = (int)GameManager.Instance.playerManager.playerLife;
    }

    // Update is called once per frame
    void Update()
    {
        playerLife.text = playerHp.ToString();
    }
}
