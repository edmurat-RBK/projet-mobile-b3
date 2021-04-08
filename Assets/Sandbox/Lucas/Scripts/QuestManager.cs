using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestManager : MonoBehaviour
{
    public int numberOfQuests;

    enum QuestsType
    {
        DestroyEnemies,
        PickupCoins,
        DestroyObstacles,
        GetScore
    }
    
    List<QuestsType> quests = new List<QuestsType>();
    
    int enemiesDestroyed;
    public int enemiesDestroyedGoal;
    int coinsPickedUp;
    public int coinsPickedUpGoal;
    int obstaclesDestroyed;
    public int obstaclesDestroyedGoal;
    int totalScore;
    public int totalScoreGoal;

    public int[] currentQuests;

    private void Start() 
    {
        InitQuests();
    }

    private void Update() 
    {
        if (enemiesDestroyed == enemiesDestroyedGoal)
        {
            if (quests.Contains(QuestsType.DestroyEnemies))
            {
                quests.Remove(QuestsType.DestroyEnemies);
                NextQuest(QuestsType.DestroyEnemies);
            }
        }
        else if(coinsPickedUp == coinsPickedUpGoal)
        {
            if (quests.Contains(QuestsType.PickupCoins))
            {
                quests.Remove(QuestsType.PickupCoins);
                NextQuest(QuestsType.PickupCoins);
            }
        }
        else if (obstaclesDestroyed == obstaclesDestroyedGoal)
        {
            if (quests.Contains(QuestsType.DestroyObstacles))
            {
                quests.Remove(QuestsType.DestroyObstacles);
                NextQuest(QuestsType.DestroyObstacles);
            }
        }
        else if (totalScore == totalScoreGoal)
        {
            if (quests.Contains(QuestsType.GetScore))
            {
                quests.Remove(QuestsType.GetScore);
                NextQuest(QuestsType.GetScore);
            }
        }
    }

    void InitQuests()
    {
        int enumCount = Enum.GetNames(typeof(QuestsType)).Length;
        for (int i = 0; i < numberOfQuests; i++)
        {   
            int rnd = UnityEngine.Random.Range(0,enumCount);
            
            if (quests.Contains((QuestsType)rnd))
            {
                i--;
            }
            else
            {
                quests.Add((QuestsType)rnd);
                Debug.Log(quests[i]);
            }
        }
    }

    void NextQuest(QuestsType questsType)
    {
        int enumCount = Enum.GetNames(typeof(QuestsType)).Length;
        int rnd = UnityEngine.Random.Range(0,enumCount);
            
        if (quests.Contains((QuestsType)rnd) || quests.Contains(questsType))
        {
            NextQuest(questsType);
        }
        else
        {
            quests.Add((QuestsType)rnd);
                
        }
    }
}
