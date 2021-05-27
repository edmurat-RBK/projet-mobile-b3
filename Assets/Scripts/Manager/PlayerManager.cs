using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;

    
    public bool revive;
    
    public bool playerIsAlive;
    public bool playerIsBoosting = false;
    public bool shieldActive = false;
    
    // public bool refilableShield;
    // public bool rechargeShield;

    public float maxShield = 10f;
    public float shield = 0f;
    public float maxPlayerLife = 10f;
    public float playerLife = 10f;
    public float maxFuelIncrease = 10f;

    public float shieldRechargeRate = 1f;
    public float lifeDecreaseSpeed = 1f;
    public float decreaseMultiplicator = 0f;
    public float fuelMultiplier = 1f;






    [Space(30)]
    [Header("Upgrades")]
    [Space(5)]

    public int lifeUpgrade;
    public int boostCoolDownUpgrade;
    public int boostDamages;





    private void Start()
    {
        InitValues();
        
    }

    
    



    void InitValues()
    {
        lifeUpgrade = 1;
        boostCoolDownUpgrade = 1;
        boostDamages = 1;
    }
}
