using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerBehavior : GlobalEnnemiBehavior
{
    public GameObject minePrefab;

    bool readyToMining = false;
    bool hasFinishAttack = false;


    private void Start()
    {
        life = GameManager.Instance.ennemiManager.minerLife;
        StartCoroutine(RandomiseDirection());
    }

    private void Update()
    {
        if (isAlive)
        {
            Vector3 playerPos = GameManager.Instance.playerManager.player.transform.position;
            float xDrop = GameManager.Instance.ennemiManager.xPosForDrop;

            if (transform.position.z <= (playerPos.z + xDrop) && !hasFinishAttack)
            {
                if(readyToMining == false)
                {
                    StartCoroutine(attackDuration());
                }
            }


            MoveBack(true);

            Movement();
            CheckDirection();
            CheckForPlayer();
            CheckBehind();
        }





        if (life <= 0 || transform.position.z < GameManager.Instance.ennemiManager.deadZone.position.z)
        {
            Instantiate(GameManager.Instance.ennemiManager.deathFX, transform.position, Quaternion.identity);
            ResetEnemy();
            Death(GameManager.Instance.otherWorldManager.bumpedStored, GameManager.Instance.ennemiManager.minerLoot);
        }
        if (transform.position.z < GameManager.Instance.ennemiManager.deadZone.position.z)
        {
            ResetEnemy();
            Teleport(GameManager.Instance.otherWorldManager.bumpedStored);
        }
    }





    IEnumerator attackDuration()
    {
        readyToMining = true;
        StartCoroutine(setMineOnTheWay());
        yield return new WaitForSeconds(GameManager.Instance.ennemiManager.stopDuration);
        readyToMining = false;
        hasFinishAttack = true;
    }
    IEnumerator setMineOnTheWay()
    {
        yield return new WaitForSeconds(GameManager.Instance.ennemiManager.minerDropRate);

        float index = Random.Range(-5, 5);
        Vector3 spawnPos = new Vector3(transform.position.x + index, transform.position.y +1, transform.position.z);
        Instantiate(minePrefab, spawnPos, transform.rotation);

        if(hasFinishAttack == false)
        {
            StartCoroutine(setMineOnTheWay());
        }
    }



    void ResetEnemy()
    {
        GlobalReset();

        life = GameManager.Instance.ennemiManager.minerLife;

        readyToMining = false;
        hasFinishAttack = false;
    }
}