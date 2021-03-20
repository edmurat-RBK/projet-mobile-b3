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



    private void Start()
    {
        GameManager.Instance.ennemiManager.ennemiList.Add(this.gameObject);

        StartCoroutine(RandomiseDirection());
    }
    private void Update()
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

        


        if (ennemiLife <= 0 || transform.position.z < GameManager.Instance.ennemiManager.deadZone.position.z)
        {
            Death();
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
                    StartCoroutine(GameManager.Instance.playerManager.player.GetComponent<PlayerController>().playerBumped(Vector3.left));
                }
                else if(playerOnRight == true)
                {
                    StartCoroutine(GameManager.Instance.playerManager.player.GetComponent<PlayerController>().playerBumped(Vector3.right));
                }

                
                isBumping = false;
                StartCoroutine(BumpCoolDown());
            }
        }
    }



    IEnumerator BumpPlayer()
    {
        isBumping = true;
        yield return new WaitForSeconds(GameManager.Instance.ennemiManager.bumperAttackDuration);
        isBumping = false;
        StartCoroutine(BumpCoolDown());
    }
    public IEnumerator BumpCoolDown()
    {
        canBump = false;
        yield return new WaitForSeconds(GameManager.Instance.ennemiManager.bumperAttackCoolDown);
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
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.left, GameManager.Instance.ennemiManager.bumperAttackSpeed*Time.deltaTime);
        }
        else if(playerOnRight == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.right, GameManager.Instance.ennemiManager.bumperAttackSpeed * Time.deltaTime);
        }
        
    }
}
