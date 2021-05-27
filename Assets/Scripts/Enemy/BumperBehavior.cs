using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Matis Duperray
/// Comportement propre à l'ennemi "Bumper"
/// </summary>
public class BumperBehavior : GlobalEnnemiBehavior
{
    bool isBumping = false;
    bool canBump = false;
    bool firstBump = true;
    Animator animator;


    private void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        ennemiManager = GameManager.Instance.ennemiManager;
        playerManager = GameManager.Instance.playerManager;
        terrainManager = GameManager.Instance.terrainManager;
        life = ennemiManager.bumperLife;
        StartCoroutine(RandomiseDirection());
    }
    private void Update()
    {
        if(isAlive)
        {
            if (isBumping)
            {
                BumpMovement();
            }
            else
            {
                Movement();
                MoveBack(true);
            }

            CheckDirection();
            CheckForPlayer();
            CheckBehind();



            BumperAttack();

            animator.SetBool("bumperIsAttacking",isBumping);
        }
        

        


        if (life <= 0)
        {
            ResetEnemy();
            Death(GameManager.Instance.otherWorldManager.bumpedStored, ennemiManager.bumperLoot);
        }
        if(transform.position.z < ennemiManager.deadZone.position.z)
        {
            Debug.Log("Bumper Out");
            ResetEnemy();
            Teleport(GameManager.Instance.otherWorldManager.bumpedStored);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isBumping)
            {
                StopCoroutine(BumpPlayer());
                Debug.Log("BOUM");

                if(playerOnLeft == true)
                {
                    StartCoroutine(playerManager.player.GetComponent<PlayerController>().playerBumped(Vector3.left));
                }
                else if(playerOnRight == true)
                {
                    StartCoroutine(playerManager.player.GetComponent<PlayerController>().playerBumped(Vector3.right));
                }

                
                isBumping = false;
                StartCoroutine(BumpCoolDown());
            }
        }
    }



    IEnumerator BumpPlayer()
    {
        isBumping = true;
        yield return new WaitForSeconds(ennemiManager.bumperAttackDuration);
        isBumping = false;
        StartCoroutine(BumpCoolDown());
    }
    public IEnumerator BumpCoolDown()
    {
        canBump = false;
        yield return new WaitForSeconds(ennemiManager.bumperAttackCoolDown);
        canBump = true;
    }


    void BumperAttack()
    {
        if (playerOnLeft || playerOnRight)
        {
            if (firstBump == true)
            {
                Debug.Log("Ok, pret a attaquer");
                StartCoroutine(BumpCoolDown());
                firstBump = false;
            }
            if (!isBumping && canBump && firstBump == false)
            {
                Debug.Log("J'attaque !");
                StartCoroutine(BumpPlayer());
            }
        }
    }
    void BumpMovement()
    {
        if (playerOnLeft == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.left, ennemiManager.bumperAttackSpeed*Time.deltaTime);
        }
        else if(playerOnRight == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.right, ennemiManager.bumperAttackSpeed * Time.deltaTime);
        }
        
    }





    void ResetEnemy()
    {
        GlobalReset();

        life = ennemiManager.bumperLife;

        isBumping = false;
        canBump = false;
        firstBump = true;
    }
}
