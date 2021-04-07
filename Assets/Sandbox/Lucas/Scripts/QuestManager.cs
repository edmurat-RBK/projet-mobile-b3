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
    
    QuestsType[] quests;
    public int enemiesDestroyed;
    public int coinsPickedUp;
    public int obstaclesDestroyed;
    public int totalScore;

    public int[] currentQuests;

    private void Start() 
    {
        quests = new QuestsType[numberOfQuests];
        SelectNextQuest();
    }

    void SelectNextQuest()
    {
        int enumCount = Enum.GetNames(typeof(QuestsType)).Length;
        for (int i = 0; i < quests.Length; i++)
        {
            
            int rnd = UnityEngine.Random.Range(0,enumCount);
            quests[i] = (QuestsType)rnd;
            if (i!=0)
            {
                if (quests[i] == quests[i-1] )
                {
                    i --;
                }
            }
            
            Debug.Log(quests[i]);
        }
    }
}
