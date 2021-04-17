using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject Quests;

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void QuestsDisplay()
    {
        Quests.SetActive(true);
        pauseMenuUI.SetActive(false);
    }
    public void CloseQuestsDisplay()
    {
        Quests.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
}
