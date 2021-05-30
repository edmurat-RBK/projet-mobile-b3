using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamerBehavior : GlobalEnnemiBehavior
{
    public GameObject fireTailPrefab;

    bool readyToFlaming = false;
    bool hasFinishAttack = false;

    Animator animator;


    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
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
            animator.SetBool("fireIsAttacking",readyToFlaming);
        }






        if (life <= 0)
        {
            ResetEnemy();
            Death(GameManager.Instance.otherWorldManager.bumpedStored, ennemiManager.flamerLoot);
        }
        if(transform.position.z < ennemiManager.deadZone.position.z || transform.position.x < -100 || transform.position.x > 100)
        {
            ResetEnemy();
            Teleport(GameManager.Instance.otherWorldManager.flamerStored);
        }

    }



    IEnumerator attackDuration()
    {
        readyToFlaming = true;

        Vector3 position = transform.position;
        position.z -= 5;

        Debug.Log("Feu");
        GameObject fireTail = Instantiate(fireTailPrefab, position, transform.rotation, transform);
        AudioManager.AMInstance.flamerStartAudio.Post(gameObject);

        yield return new WaitForSeconds(ennemiManager.flamerAttackDuration);
        Destroy(fireTail);
        AudioManager.AMInstance.flamerEndAudio.Post(gameObject);

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
