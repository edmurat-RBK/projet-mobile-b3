using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header ("Highscore")]
    public Text highScoreText;
    float highScore;
    public int displayedScore;
    [HideInInspector]
    public float multiplier;

    [Header ("Life")]
    public Text playerLife;
    public Slider hpSlider;
    int playerHp;

    [Header("Money")]
    public Text playerCoins;
    void Start()
    {
        multiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        #region highscore
        displayedScore = (int)highScore; 

        highScoreText.text = displayedScore.ToString(); 

        highScore = highScore + (GameManager.Instance.terrainManager.scrollSpeed / GameManager.Instance.terrainManager.baseScrollspeed) * Time.deltaTime * multiplier;
        #endregion

        #region Life
        hpSlider.value = GameManager.Instance.playerManager.playerLife/GameManager.Instance.playerManager.maxPlayerLife;
        playerHp = (int)GameManager.Instance.playerManager.playerLife;
        playerLife.text = playerHp.ToString();
        #endregion

        #region Money
        playerCoins.text = GameManager.Instance.economicManager.coinCounter.ToString();
        #endregion
    }

    void LoadValues()
    {
        ShopData data = DataManager.DMInstance.LoadShop();
        
        
        if (data != null)
        {
            
            multiplier = data.scoreMulti;
            
            
        }
        
    }
}
