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
    
    public int enemiesDestroyed;
    public int coinsPickedUp;
    public int obstaclesDestroyed;
    public int totalScore;

    public int[] currentQuests;

    private void Start() 
    {
        SelectNextQuest();
    }

    void SelectNextQuest()
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
}
