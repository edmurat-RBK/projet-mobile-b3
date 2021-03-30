using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadMenu : MonoBehaviour
{
    public Text highscoreText;
    public Text coinsText;
    int highscore;
    int coins;
    // Start is called before the first frame update
    void Start()
    {
        LoadValues();
    }

    // Update is called once per frame
    void LoadValues()
    {
        Datas data = DataManager.DMInstance.Load();

        if (data != null)
        {
            coins = data.coinsCollected;
            highscore = data.highscore;
        }
        DisplayValues();
    }

    void DisplayValues()
    {
        highscoreText.text = "Hiscore: " + highscore.ToString();
        coinsText.text = "Coins: " + coins.ToString();
    }
}
