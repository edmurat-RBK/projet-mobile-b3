using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestsDisplay : MonoBehaviour
{
    bool runOnce = true;
    public List<Text> questNames = new List<Text>();
    public List<Slider> firstList = new List<Slider>();
    public List<Slider> secondList = new List<Slider>();
    public List<Slider> thirdList = new List<Slider>();
    public List<List<Slider>> questsProgression = new List<List<Slider>>();
    
    // Start is called before the first frame update
    private void OnEnable() 
    {
        
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        if (runOnce)
        {
            questsProgression.Add(firstList);
            questsProgression.Add(secondList);
            questsProgression.Add(thirdList);
            runOnce = false;
            
        }
        
        for (var i = 0; i < GameManager.Instance.questManager.numberOfQuests; i++)
        {
            
            questNames[i].text = GameManager.Instance.questManager.quests[i].questname;
            for (var j = 0; j < questsProgression[i].Count; j++)
            {
                questsProgression[i][j].gameObject.SetActive(false);
            }
            
            if (GameManager.Instance.questManager.quests[i].objectsToDestroy>0)
            {
                questsProgression[i][0].gameObject.SetActive(true);
                questsProgression[i][1].value = GameManager.Instance.questManager.obstaclesDestroyed[i]/GameManager.Instance.questManager.quests[i].objectsToDestroy;
            }
            if (GameManager.Instance.questManager.quests[i].enemiesToKill>0)
            {
                questsProgression[i][1].gameObject.SetActive(true);
                questsProgression[i][1].value = GameManager.Instance.questManager.enemiesDestroyed[i]/GameManager.Instance.questManager.quests[i].enemiesToKill;  
            }
            if (GameManager.Instance.questManager.quests[i].coinsToPickup>0)
            {
                questsProgression[i][2].gameObject.SetActive(true);
                questsProgression[i][1].value = GameManager.Instance.questManager.coinsPickedUp[i]/GameManager.Instance.questManager.quests[i].coinsToPickup;
            }
            if (GameManager.Instance.questManager.quests[i].scoreToReach>0)
            {
                questsProgression[i][3].gameObject.SetActive(true);
                questsProgression[i][1].value = GameManager.Instance.questManager.totalScore[i]/GameManager.Instance.questManager.quests[i].scoreToReach;
            } 
        }
    }


}
