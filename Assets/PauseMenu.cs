using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject Quests;
    
    public void QuitToMenu()
    {
        SceneManager.LoadScene("Menu Start");
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

        AudioManager.AMInstance.UIUnpauseAudio.Post(gameObject);
    }

    public void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

        AudioManager.AMInstance.UIPauseAudio.Post(gameObject);
    }

    public void QuestsDisplay()
    {
        Quests.SetActive(true);
        pauseMenuUI.SetActive(false);

        AudioManager.AMInstance.UISelectAudio.Post(gameObject);
    }
    public void CloseQuestsDisplay()
    {
        Quests.SetActive(false);
        pauseMenuUI.SetActive(true);

        AudioManager.AMInstance.UICloseAudio.Post(gameObject);
    }
}
