using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Matis Duperray
/// Comportement propre à l'ennemi "Dummy"
/// </summary>
public class DummyBehavior : GlobalEnnemiBehavior
{

    public GameObject explosionDeathDummy;

    private void Start()
    {
        ennemiManager = GameManager.Instance.ennemiManager;
        playerManager = GameManager.Instance.playerManager;
        terrainManager = GameManager.Instance.terrainManager;
        life = ennemiManager.dummyLife;
        explosionDeathDummy.SetActive(false);
        StartCoroutine(RandomiseDirection());

        
    }
    private void Update()
    {
        if(isAlive)
        {
            Movement();
            MoveBack(false);


            CheckDirection();
            CheckForPlayer();
            CheckBehind();
        }

        


        if(life <= 0)
        {
            Instantiate(explosionDeathDummy);
            ResetEnemy();
            Death(GameManager.Instance.otherWorldManager.dummyStored, ennemiManager.dummyLoot);
        }
        if(transform.position.z < ennemiManager.deadZone.position.z || transform.position.x < -100 || transform.position.x > 100)
        {
            ResetEnemy();
            Teleport(GameManager.Instance.otherWorldManager.dummyStored);
        }
    }



    void ResetEnemy()
    {
        GlobalReset();
        
        life = ennemiManager.dummyLife;
    }
}
