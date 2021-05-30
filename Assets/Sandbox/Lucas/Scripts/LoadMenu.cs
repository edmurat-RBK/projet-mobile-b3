using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class LoadMenu : MonoBehaviour
{
    public Text highscoreText;
    public Text coinsText;
    public Text purpleCoinsText;
    public int highscore;
    public int coins;
    public int purpleCoins;
    public bool tutorial;
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
            
            purpleCoins += data.purpleCoins;
            coins = data.coinsCollected;
            Debug.Log(data.purpleCoins);
            highscore = data.highscore;
            
        }
        
        DisplayValues();
    }

    

    public void DisplayValues()
    {
        highscoreText.text = "Hiscore: " + highscore.ToString();
        coinsText.text = coins.ToString();
        purpleCoinsText.text = purpleCoins.ToString();
    }
    
}
