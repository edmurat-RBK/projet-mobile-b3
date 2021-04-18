using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamerBehavior : GlobalEnnemiBehavior
{
    public GameObject fireTailPrefab;

    bool readyToFlaming = false;
    bool hasFinishAttack = false;


    private void Start()
    {
        ennemiManager = GameManager.Instance.ennemiManager;
        playerManager = GameManager.Instance.playerManager;
        terrainManager = GameManager.Instance.terrainManager;
        life = ennemiManager.flamerLife;
        StartCoroutine(RandomiseDirection());
    }

    private void Update()
    {
        if (isAlive)
        {
            Vector3 playerPos = playerManager.player.transform.position;
            float xDrop = ennemiManager.xPosForFire;

            if (transform.position.z >= (playerPos.z + xDrop - 0.5) && transform.position.z <= (playerPos.z + xDrop + 0.5) && !hasFinishAttack)
            {
                if (readyToFlaming == false)
                {
                    StartCoroutine(attackDuration());
                }

                if (readyToFlaming && playerManager.playerIsBoosting)
                {
                    MoveBack(false);
                }
            }
            else
            {
                Movement();
                MoveBack(true);
            }

            CheckDirection();
            CheckForPlayer();
            CheckBehind();
        }





        if (life <= 0)
        {
            Instantiate(ennemiManager.deathFX, transform.position, Quaternion.identity);
            ResetEnemy();
            Death(GameManager.Instance.otherWorldManager.bumpedStored, ennemiManager.flamerLoot);
        }
        if(transform.position.z < ennemiManager.deadZone.position.z)
        {
            Debug.Log("Flamer Out");
            ResetEnemy();
            Teleport(GameManager.Instance.otherWorldManager.flamerStored);
        }

    }





    IEnumerator attackDuration()
    {
        readyToFlaming = true;

        GameObject fireTail = Instantiate(fireTailPrefab, transform.position, transform.rotation, transform);
        fireTail.transform.position = new Vector3(fireTail.transform.position.x, fireTail.transform.position.y, transform.position.z - (fireTail.transform.localScale.z / 2));

        yield return new WaitForSeconds(ennemiManager.flamerAttackDuration);
        Destroy(fireTail);

        readyToFlaming = false;
        hasFinishAttack = true;
    }



    void ResetEnemy()
    {
        GlobalReset();

        life = ennemiManager.minerLife;

        readyToFlaming = false;
        hasFinishAttack = false;
    }
}
