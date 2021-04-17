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
        
        for (var i = 0; i < GameManager.Instance.questManager.numberOfQuests-1; i++)
        {
            
            questNames[i].text = GameManager.Instance.questManager.quests[i].questname;
            for (var j = 0; j < questsProgression[i].Count; j++)
            {
                questsProgression[i][j].enabled = false;
            }
            if (GameManager.Instance.questManager.quests[i].objectsToDestroy>0)
            {
                questsProgression[i][1].enabled = true;
                questsProgression[i][1].value = GameManager.Instance.questManager.quests[i].objectsToDestroy/GameManager.Instance.questManager.obstaclesDestroyed[i];
            }
            if (GameManager.Instance.questManager.quests[i].enemiesToKill>0)
            {
                questsProgression[i][2].enabled = true;
                questsProgression[i][1].value = GameManager.Instance.questManager.quests[i].enemiesToKill/GameManager.Instance.questManager.enemiesDestroyed[i];  
            }
            if (GameManager.Instance.questManager.quests[i].coinsToPickup>0)
            {
                questsProgression[i][3].enabled = true;
                questsProgression[i][1].value = GameManager.Instance.questManager.quests[i].coinsToPickup/GameManager.Instance.questManager.coinsPickedUp[i];
            }
            if (GameManager.Instance.questManager.quests[i].scoreToReach>0)
            {
                questsProgression[i][4].enabled = true;
                questsProgression[i][1].value = GameManager.Instance.questManager.quests[i].scoreToReach/GameManager.Instance.questManager.totalScore[i];
            }
        }
    }


}
