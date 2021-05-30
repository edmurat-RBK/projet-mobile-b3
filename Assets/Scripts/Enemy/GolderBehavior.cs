using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolderBehavior : GlobalEnnemiBehavior
{
    public GameObject coinPrefab;
    bool hasStartDroping = false;
    bool acceleration = false;
    Animator animator;

    public GameObject explosionGolderDeath;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        ennemiManager = GameManager.Instance.ennemiManager;
        playerManager = GameManager.Instance.playerManager;
        terrainManager = GameManager.Instance.terrainManager;
        life = ennemiManager.dummyLife;
        
        StartCoroutine(RandomiseDirection());
    }

    void Update()
    {
        if (isAlive)
        {
            if(!acceleration)
            {
                Movement();
                MoveBack(false);


                CheckDirection();
                CheckForPlayer();
                CheckBehind();



                if (hasStartDroping == false)
                {
                    StartCoroutine(dropCoin());
                    StartCoroutine(stayBeforeLeave());
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.forward * 100), terrainManager.scrollSpeed * Time.deltaTime);
            }

        }




        if (life <= 0)
        {
            Instantiate(explosionGolderDeath, transform.position, transform.rotation);
            ResetEnemy();
            Death(GameManager.Instance.otherWorldManager.golderStored, ennemiManager.golderLoot);
        }
        if(transform.position.z < ennemiManager.deadZone.position.z || transform.position.x < -100 || transform.position.x > 100)
        {
            ResetEnemy();
            Teleport(GameManager.Instance.otherWorldManager.golderStored);
        }

        animator.SetBool("coinIsDropping",hasStartDroping);
    }

    IEnumerator dropCoin()
    {
        if (hasStartDroping == false)
        {
            hasStartDroping = true;
        }



        if (!acceleration)
        {
            Vector3 position = transform.position;

            AudioManager.AMInstance.coinDropAudio.Post(gameObject);

            Debug.Log("Drop Coin");
            GameObject coin = Instantiate(coinPrefab, position, transform.rotation);
            Debug.Log(coin);
            coin.GetComponent<Coin>().coinNeedToMove = true;
        }


        yield return new WaitForSeconds(ennemiManager.golderDropRate);

        if (!acceleration)
        {
            StartCoroutine(dropCoin());
        }
    }
    IEnumerator stayBeforeLeave()
    {
        yield return new WaitForSeconds(ennemiManager.gloderStayDuration);
        acceleration = true;
        yield return new WaitForSeconds(3);

        ResetEnemy();
        Teleport(GameManager.Instance.otherWorldManager.golderStored);
    }


    void ResetEnemy()
    {
       
        GlobalReset();

        life = ennemiManager.golderLife;
        hasStartDroping = false;
        acceleration = false;
    }
}
