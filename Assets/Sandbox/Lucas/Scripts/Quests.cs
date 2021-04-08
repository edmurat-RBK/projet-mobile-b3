using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quests : ScriptableObject
{
    public string questname;
    public bool destroyObjects;
    public int objectsToDestroy;
    public bool killEnemies;
    public int enemiesToKill;
    public bool pickupCoins;
    public int coinsToPickup;
    public bool reachScore;
    public int scoreToReach;
}
