using System.Collections;
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

    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void OpenShop()
    {
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
}
