using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolderBehavior : GlobalEnnemiBehavior
{
    public GameObject coinPrefab;
    bool hasStartDroping = false;
    bool acceleration = false;
    private EnnemiManager ennemiManager;

    private void Start()
    {
        ennemiManager = GameManager.Instance.ennemiManager;
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
                transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.forward * 100), GameManager.Instance.terrainManager.scrollSpeed * Time.deltaTime);
            }

        }




        if (life <= 0)
        {
            Instantiate(ennemiManager.deathFX, transform.position, Quaternion.identity);
            ResetEnemy();
            Death(GameManager.Instance.otherWorldManager.golderStored, ennemiManager.golderLoot);
        }
        if(transform.position.z < ennemiManager.deadZone.position.z)
        {
            Debug.Log("Golder Out");
            ResetEnemy();
            Teleport(GameManager.Instance.otherWorldManager.golderStored);
        }
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
            position.y += 0;

            GameObject coin = Instantiate(coinPrefab, position, transform.rotation);
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
