﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuButtons;
    [Header("Shop Buttons")]
    public GameObject shopButtons;
    [Header("Option Buttons")]
    public GameObject optionButtons;
    [Header("Quests Buttons")]
    public GameObject questsButtons;

    public ShopMacro1 shopMacro;
    public LoadMenu loadMenu;
    

    public GameObject tuto;
    private void Start() 
    {
        
    }

    public void ChangeScene(int index)
    {
        
        DataManager.DMInstance.ShopSave(shopMacro.boostUnlocked,shopMacro.multiplier,shopMacro.doubleCoins,shopMacro.revive,shopMacro.maxLife,shopMacro.startShield,loadMenu.tutorial);
        SceneManager.LoadScene(index);
        AudioManager.AMInstance.UIStartAudio.Post(gameObject);
        AudioManager.AMInstance.playerMotorAudio.Post(gameObject);
    }
    public void DisplayTuto()
    {
        tuto.SetActive(true);
        GetComponent<Tutorial>().NextStep();
    }

    public void OpenShop()
    {
        Debug.Log("hahah    ");
        shopButtons.SetActive(true);
        mainMenuButtons.SetActive(false);

        AudioManager.AMInstance.UISelectAudio.Post(gameObject);
    }
    public void CloseShop()
    {
        DataManager.DMInstance.ShopSave(shopMacro.boostUnlocked,shopMacro.multiplier,shopMacro.doubleCoins,shopMacro.revive,shopMacro.maxLife,shopMacro.startShield,loadMenu.tutorial);
        Debug.Log(shopMacro.boostUnlocked);
        shopButtons.SetActive(false);
        mainMenuButtons.SetActive(true);

        AudioManager.AMInstance.UICloseAudio.Post(gameObject);
    }
    public void OpenOtions()
    {
        optionButtons.SetActive(true);
        mainMenuButtons.SetActive(false);

        AudioManager.AMInstance.UISelectAudio.Post(gameObject);
    }
    public void CloseOptions()
    {
        optionButtons.SetActive(false);
        mainMenuButtons.SetActive(true);

        AudioManager.AMInstance.UICloseAudio.Post(gameObject);
    }
    public void OpenQuests()
    {
        questsButtons.SetActive(true);
        mainMenuButtons.SetActive(false);

        AudioManager.AMInstance.UISelectAudio.Post(gameObject);
    }
    public void CloseQuests()
    {
        questsButtons.SetActive(false);
        mainMenuButtons.SetActive(true);

        AudioManager.AMInstance.UICloseAudio.Post(gameObject);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
