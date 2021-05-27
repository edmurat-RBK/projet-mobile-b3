using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerBehavior : GlobalEnnemiBehavior
{
    public GameObject minePrefab;

    bool readyToMining = false;
    bool hasFinishAttack = false;

    Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        ennemiManager = GameManager.Instance.ennemiManager;
        playerManager = GameManager.Instance.playerManager;
        terrainManager = GameManager.Instance.terrainManager;
        life = ennemiManager.minerLife;
        StartCoroutine(RandomiseDirection());
    }

    private void Update()
    {
        if (isAlive)
        {
            Vector3 playerPos = playerManager.player.transform.position;
            float xDrop = ennemiManager.xPosForDrop;

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





        if (life <= 0 || transform.position.z < ennemiManager.deadZone.position.z)
        {
            ResetEnemy();
            Death(GameManager.Instance.otherWorldManager.bumpedStored, ennemiManager.minerLoot);
        }
        if (transform.position.z < ennemiManager.deadZone.position.z)
        {
            Debug.Log("Miner Out");
            ResetEnemy();
            Teleport(GameManager.Instance.otherWorldManager.bumpedStored);
        }

        animator.SetBool("bomberIsAttacking",readyToMining);
    }





    IEnumerator attackDuration()
    {
        readyToMining = true;
        StartCoroutine(setMineOnTheWay());
        yield return new WaitForSeconds(ennemiManager.stopDuration);
        readyToMining = false;
        hasFinishAttack = true;
    }
    IEnumerator setMineOnTheWay()
    {
        yield return new WaitForSeconds(ennemiManager.minerDropRate);

        float index = Random.Range(-5, 5);
        Vector3 spawnPos = new Vector3(transform.position.x + index, transform.position.y +1, transform.position.z);

        AudioManager.AMInstance.minerBlastAudio.Post(gameObject);
        Instantiate(minePrefab, spawnPos, transform.rotation);

        if(hasFinishAttack == false)
        {
            StartCoroutine(setMineOnTheWay());
        }
    }



    void ResetEnemy()
    {
        GlobalReset();

        life = ennemiManager.minerLife;

        readyToMining = false;
        hasFinishAttack = false;
    }
}