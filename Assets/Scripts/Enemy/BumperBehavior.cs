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
    bool canBump = true;



    private void Start()
    {
        GameManager.Instance.ennemiManager.ennemiList.Add(this.gameObject);
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
        


        if(playerOnLeft || playerOnRight)
        {
            if (!isBumping && canBump)
            {
                StartCoroutine(BumpPlayer());
            }
        }

        


        if (ennemiLife <= 0 || transform.position.z < GameManager.Instance.ennemiManager.deadZone.position.z)
        {
            Death();
        }
    }



    IEnumerator BumpPlayer()
    {
        isBumping = true;
        yield return new WaitForSeconds(GameManager.Instance.ennemiManager.bumperAttackDuration);
        isBumping = false;
        StartCoroutine(BumpCoolDown());
    }
    IEnumerator BumpCoolDown()
    {
        canBump = false;
        yield return new WaitForSeconds(GameManager.Instance.ennemiManager.bumperAttackCoolDown);
        canBump = true;
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
