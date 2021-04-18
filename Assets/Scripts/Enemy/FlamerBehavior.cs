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
        life = GameManager.Instance.ennemiManager.flamerLife;
        StartCoroutine(RandomiseDirection());
    }

    private void Update()
    {
        if (isAlive)
        {
            Vector3 playerPos = GameManager.Instance.playerManager.player.transform.position;
            float xDrop = GameManager.Instance.ennemiManager.xPosForFire;

            if (transform.position.z >= (playerPos.z + xDrop - 0.5) && transform.position.z <= (playerPos.z + xDrop + 0.5) && !hasFinishAttack)
            {
                if (readyToFlaming == false)
                {
                    StartCoroutine(attackDuration());
                }

                if (readyToFlaming && GameManager.Instance.playerManager.playerIsBoosting)
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
            Instantiate(GameManager.Instance.ennemiManager.deathFX, transform.position, Quaternion.identity);
            ResetEnemy();
            Death(GameManager.Instance.otherWorldManager.bumpedStored, GameManager.Instance.ennemiManager.flamerLoot);
        }
        if(transform.position.z < GameManager.Instance.ennemiManager.deadZone.position.z)
        { 
            ResetEnemy();
            Teleport(GameManager.Instance.otherWorldManager.flamerStored);
        }

    }





    IEnumerator attackDuration()
    {
        readyToFlaming = true;

        GameObject fireTail = Instantiate(fireTailPrefab, transform.position, transform.rotation);
        fireTail.transform.position = new Vector3(fireTail.transform.position.x, fireTail.transform.position.y, transform.position.z - (fireTail.transform.localScale.z / 2));

        yield return new WaitForSeconds(GameManager.Instance.ennemiManager.flamerAttackDuration);
        Destroy(fireTail);

        readyToFlaming = false;
        hasFinishAttack = true;
    }



    void ResetEnemy()
    {
        GlobalReset();

        life = GameManager.Instance.ennemiManager.minerLife;

        readyToFlaming = false;
        hasFinishAttack = false;
    }
}
