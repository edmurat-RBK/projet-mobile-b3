using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    public Tutorial tutorial;
    [Header("Highscore")]
    public Text highScoreText;
    float highScore;
    public int displayedScore;
    [HideInInspector]
    public float multiplier;
    [HideInInspector]
    public bool multiply;

    [Header("Life")]
    public Text playerLife;
    public Slider hpSlider;
    int playerHp;

    [Header("Money")]
    public Text playerCoins;
    void Start()
    {
        tutorial = FindObjectOfType<Tutorial>();
        if (multiply)
        {
            multiplier = 2;
            StartCoroutine(StopMulti());
        }
        else
        {
            multiplier = 1;
        }
        if (GameManager.Instance.economicManager.doubleCoins)
        {
            StartCoroutine(StopDoubleCoins());
        }
        LoadValues();
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
        hpSlider.value = GameManager.Instance.playerManager.playerLife / GameManager.Instance.playerManager.maxPlayerLife;
        playerHp = (int)GameManager.Instance.playerManager.playerLife;
        playerLife.text = playerHp.ToString();
        #endregion

        #region Money
        playerCoins.text = GameManager.Instance.economicManager.coinCounter.ToString();
        #endregion
    }

    IEnumerator StopMulti()
    {
        yield return new WaitForSeconds(30);
        multiplier = 1;
    }
    IEnumerator StopDoubleCoins()
    {
        yield return new WaitForSeconds(15);
        GameManager.Instance.economicManager.doubleCoins = false;
    }
    void LoadValues()
    {
        ShopData data = DataManager.DMInstance.LoadShop();
        Debug.Log(data);

        if (data != null)
        {
            
            GameManager.Instance.playerManager.tutorial = data.tutorial;
            tutorial.StartTutorial();
            GameManager.Instance.playerManager.boostCharges += data.unlockBoost;
            GameManager.Instance.playerManager.revive = data.revive;
            GameManager.Instance.playerManager.shieldActive = data.startShield;
            GameManager.Instance.playerManager.maxPlayerLife += data.maxLife;
            GameManager.Instance.economicManager.doubleCoins = data.doubleCoins;
            multiply = data.scoreMulti;
        }

    }
}
