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
    [Header("Quests Buttons")]
    public GameObject questsButtons;

    public ShopMacro1 shopMacro;
    
    private void Start() {
        
    }

    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);

        AudioManager.AMInstance.UIStartAudio.Post(gameObject);
        AudioManager.AMInstance.playerMotorAudio.Post(gameObject);
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
}
