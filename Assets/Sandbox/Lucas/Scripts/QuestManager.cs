using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestManager : MonoBehaviour
{
    public int numberOfQuests;

    // enum QuestsType
    // {
    //     DestroyEnemies,
    //     PickupCoins,
    //     DestroyObstacles,
    //     GetScore
    // }
    
    //List<QuestsType> quests = new List<QuestsType>();
    public List<Quests> questsList = new List<Quests>();
    public List<Quests> quests = new List<Quests>();
    
    public int[] obstaclesDestroyed;

    public int[] enemiesDestroyed;
    
    public int[] coinsPickedUp;
    
    public int[] totalScore;
    
    
    

    private void Start() 
    {
        obstaclesDestroyed = new int[numberOfQuests];
        enemiesDestroyed = new int[numberOfQuests];
        coinsPickedUp = new int[numberOfQuests];
        totalScore = new int[numberOfQuests];

        InitQuests();
    }

    private void FixedUpdate() 
    {
        if (quests.Count == numberOfQuests)
        {
           for (var i = 0; i < quests.Count-1; i++)
            {
                if (enemiesDestroyed[i]>=quests[i].enemiesToKill && coinsPickedUp[i]>= quests[i].coinsToPickup && obstaclesDestroyed[i] >= quests[i].objectsToDestroy && totalScore[i] >= quests[i].scoreToReach)
                {
                    QuestCompleted(quests[i],i);
                }
            } 
        }
        
    }

    // void InitQuests()
    // {
    //     int enumCount = Enum.GetNames(typeof(QuestsType)).Length;
    //     for (int i = 0; i < numberOfQuests; i++)
    //     {   
    //         int rnd = UnityEngine.Random.Range(0,enumCount);
            
    //         if (quests.Contains((QuestsType)rnd))
    //         {
    //             i--;
    //         }
    //         else
    //         {
    //             quests.Add((QuestsType)rnd);
    //             Debug.Log(quests[i]);
    //         }
    //     }
    // }
    void InitQuests()
    {
        
        for (int i = 0; i < numberOfQuests; i++)
        {   
            int rnd = Random.Range(0,questsList.Count);

            quests.Add(questsList[rnd]);
            questsList.Remove(questsList[rnd]);
        }
    }

    void QuestCompleted(Quests quest, int index)
    {
        GameManager.Instance.economicManager.coinVioletCounter += quest.reward;
        obstaclesDestroyed[index] = 0;
        enemiesDestroyed[index] = 0;
        coinsPickedUp[index] = 0;
        totalScore[index] = 0;
        questsList.Add(quest);
        quests.Remove(quest);
        NewQuest();
    }

    void NewQuest()
    {
        int rnd = Random.Range(0,questsList.Count);
        quests.Add(questsList[rnd]);
        questsList.Remove(questsList[rnd]);
        
        
    }
    // void NextQuest(QuestsType questsType)
    // {
    //     int enumCount = Enum.GetNames(typeof(QuestsType)).Length;
    //     int rnd = UnityEngine.Random.Range(0,enumCount);
            
    //     if (quests.Contains((QuestsType)rnd) || quests.Contains(questsType))
    //     {
    //         NextQuest(questsType);
    //     }
    //     else
    //     {
    //         quests.Add((QuestsType)rnd);
                
    //     }
    // }
}
