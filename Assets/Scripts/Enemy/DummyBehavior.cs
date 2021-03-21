using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Matis Duperray
/// Comportement propre à l'ennemi "Dummy"
/// </summary>
public class DummyBehavior : GlobalEnnemiBehavior
{
    private void Start()
    {
        life = GameManager.Instance.ennemiManager.dummyLife;
        StartCoroutine(RandomiseDirection());
    }
    private void Update()
    {
        if(isAlive)
        {
            Movement();
            MoveBack(false);


            CheckDirection();
            CheckForPlayer();
            CheckBehind();
        }

        


        if(life <= 0 || transform.position.z < GameManager.Instance.ennemiManager.deadZone.position.z)
        {
            ResetEnemy();
            Death(GameManager.Instance.otherWorldManager.dummyStored);
        }
    }





    void ResetEnemy()
    {
        GlobalReset();

        life = GameManager.Instance.ennemiManager.dummyLife;
    }
}
