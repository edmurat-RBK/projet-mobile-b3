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
    
    private void Start() {
        
    }

    public void ChangeScene(int index)
    {
        DataManager.DMInstance.ShopSave(shopMacro.multiplier,shopMacro.coinsMulti,shopMacro.extraLives,shopMacro.maxLife,index);
        //SceneManager.LoadScene(index);
    }

    public void OpenShop()
    {
        Debug.Log("hahah    ");
        shopButtons.SetActive(true);
        mainMenuButtons.SetActive(false);
    }
    public void CloseShop()
    {
        shopButtons.SetActive(false);
        mainMenuButtons.SetActive(true);
    }
    public void OpenOtions()
    {
        optionButtons.SetActive(true);
        mainMenuButtons.SetActive(false);
    }
    public void CloseOptions()
    {
        optionButtons.SetActive(false);
        mainMenuButtons.SetActive(true);
    }
    public void OpenQuests()
    {
        questsButtons.SetActive(true);
        mainMenuButtons.SetActive(false);
    }
    public void CloseQuests()
    {
        questsButtons.SetActive(false);
        mainMenuButtons.SetActive(true);
    }
}
