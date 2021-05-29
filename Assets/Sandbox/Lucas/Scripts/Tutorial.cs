using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialObject;
    public List<GameObject> steps = new List<GameObject>();
    bool canChange = true;
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
            NextStep();
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
        if (i < steps.Count && canChange)
        {
            foreach (GameObject item in steps)
            {
                item.SetActive(false);
            }
            steps[i].SetActive(true);
            i += 1;
            canChange = false;
            StartCoroutine(nextStepCooldown());
        }
    }

    IEnumerator nextStepCooldown()
    {
        yield return new WaitForSecondsRealtime(1f);
        canChange = true;
    }
    
}
