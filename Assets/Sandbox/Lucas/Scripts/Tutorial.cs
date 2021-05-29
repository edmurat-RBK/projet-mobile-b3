using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialObject;
    public List<Image> steps = new List<Image>();
    int i;

    PlayerManager playerManager;    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameManager.Instance.playerManager;

    }

    public void StartTutorial()
    {
        if (playerManager.tutorial)
        {
            Debug.Log("okiokki");
            tutorialObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    // Update is called once per frame
    public void EndTutorial()
    {
        Time.timeScale = 1;
        tutorialObject.SetActive(false);
    }

    public void NextStep()
    {
        if (i < steps.Count)
        {
            steps[i].gameObject.SetActive(true);
            i += 1;
        }

    }

    public void PreviousStep()
    {
        if (i > 0)
        {
            i -= 1;
            steps[i].gameObject.SetActive(false);
            
        }
    }
}
