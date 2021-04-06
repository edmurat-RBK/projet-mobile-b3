using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolderBehavior : GlobalEnnemiBehavior
{
    public GameObject coinPrefab;
    bool hasStartDroping = false;
    bool acceleration = false;

    private void Start()
    {
        life = GameManager.Instance.ennemiManager.dummyLife;
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




        if (life <= 0 || transform.position.z < GameManager.Instance.ennemiManager.deadZone.position.z)
        {
            ResetEnemy();
            Death(GameManager.Instance.otherWorldManager.golderStored);
        }
    }



    IEnumerator dropCoin()
    {
        if (hasStartDroping == false)
        {
            hasStartDroping = true;
        }
        Debug.Log("DROP COIN");




        if (!acceleration)
        {
            Vector3 position = transform.position;
            position.y += 0;

            GameObject coin = Instantiate(coinPrefab, position, transform.rotation);
            coin.GetComponent<Coin>().coinNeedToMove = true;
        }


        yield return new WaitForSeconds(GameManager.Instance.ennemiManager.golderDropRate);

        if (!acceleration)
        {
            StartCoroutine(dropCoin());
        }
    }
    IEnumerator stayBeforeLeave()
    {
        yield return new WaitForSeconds(GameManager.Instance.ennemiManager.gloderStayDuration);
        acceleration = true;
        yield return new WaitForSeconds(3);

        ResetEnemy();
        Death(GameManager.Instance.otherWorldManager.golderStored);
    }


    void ResetEnemy()
    {
        GlobalReset();

        life = GameManager.Instance.ennemiManager.golderLife;
        hasStartDroping = false;
        acceleration = false;
    }
}
